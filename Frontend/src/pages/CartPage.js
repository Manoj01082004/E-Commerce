import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import {
    FaMinus,
    FaPlus,
    FaTrashCan
} from "react-icons/fa6";
import { toast } from "react-toastify";
import { useApi } from "../context/ApiContext";
import "./CartPage.css";

const fallbackImage =
    "https://placehold.co/300x300/222c3d/ddb3a3?text=Product";

function CartPage() {
    const navigate = useNavigate();
    const { cart: cartService } = useApi();

    const [cartItems, setCartItems] = useState([]);
    const [loading, setLoading] = useState(true);
    const [updatingItemId, setUpdatingItemId] = useState(null);
    const [stockErrors, setStockErrors] = useState({});

    useEffect(() => {
    async function loadCartItems() {
        try {
            const items = await cartService.getMyCart();

            setCartItems(items);
        } catch (error) {
            toast.error(
                error.message ||
                "Unable to load your cart."
            );
        } finally {
            setLoading(false);
        }
    }

    loadCartItems();
}, [cartService]);

    async function updateQuantity(cartItem, newQuantity) {
        if (newQuantity < 1) {
            return;
        }

        if (
            cartItem.availableQuantity !== null &&
            cartItem.availableQuantity !== undefined &&
            newQuantity > cartItem.availableQuantity
        ) {
            setStockErrors((currentErrors) => ({
                ...currentErrors,
                [cartItem.id]:
                    "Out of stock, please reduce the quantity or remove the item."
            }));

            return;
        }

        try {
            setUpdatingItemId(cartItem.id);

            await cartService.updateQuantity(
                cartItem.id,
                newQuantity
            );

            setCartItems((currentItems) =>
                currentItems.map((item) =>
                    item.id === cartItem.id
                        ? {
                            ...item,
                            quantity: newQuantity
                        }
                        : item
                )
            );

            setStockErrors((currentErrors) => {
                const updatedErrors = { ...currentErrors };

                delete updatedErrors[cartItem.id];

                return updatedErrors;
            });
        } catch (error) {
            toast.error(
                error.message ||
                "Unable to update cart quantity."
            );
        } finally {
            setUpdatingItemId(null);
        }
    }

    async function removeCartItem(cartItemId) {
        try {
            setUpdatingItemId(cartItemId);

            await cartService.removeItem(cartItemId);

            setCartItems((currentItems) =>
                currentItems.filter(
                    (item) => item.id !== cartItemId
                )
            );

            toast.success("Item removed from cart.");
        } catch (error) {
            toast.error(
                error.message ||
                "Unable to remove item from cart."
            );
        } finally {
            setUpdatingItemId(null);
        }
    }

    const totalAmount = cartItems.reduce((total, item) => {
        return total + item.productPrice * item.quantity;
    }, 0);

    if (loading) {
        return (
            <p className="cart-message">
                Loading your cart...
            </p>
        );
    }

    if (cartItems.length === 0) {
        return (
            <section className="empty-cart">
                <h1>Your Cart is Empty</h1>

                <p>
                    Add products to your cart to continue shopping.
                </p>

                <Link
                    to="/products"
                    className="continue-shopping-button"
                >
                    Continue Shopping
                </Link>
            </section>
        );
    }

    return (
        <section className="cart-page">
            <div className="cart-header">
                <div>
                    <p className="cart-eyebrow">
                        YOUR SHOPPING BAG
                    </p>

                    <h1>My Cart</h1>
                </div>

                <Link
                    to="/products"
                    className="continue-shopping-link"
                >
                    ← Continue Shopping
                </Link>
            </div>

            <div className="cart-layout">
                <div className="cart-items">
                    {cartItems.map((cartItem) => (
                        <article
                            className="cart-item"
                            key={cartItem.id}
                        >
                            <img
                                src={
                                    cartItem.productImageUrl ||
                                    fallbackImage
                                }
                                alt={cartItem.productName}
                                className="cart-item-image"
                                onError={(event) => {
                                    event.currentTarget.src =
                                        fallbackImage;
                                }}
                            />

                            <div className="cart-item-details">
                                <h2>{cartItem.productName}</h2>

                                <p className="cart-item-price">
                                    $
                                    {Number(
                                        cartItem.productPrice
                                    ).toFixed(2)}
                                </p>

                                <div className="cart-item-actions">
                                    <div className="cart-quantity-selector">
                                        <button
                                            type="button"
                                            disabled={
                                                cartItem.quantity === 1 ||
                                                updatingItemId === cartItem.id
                                            }
                                            onClick={() =>
                                                updateQuantity(
                                                    cartItem,
                                                    cartItem.quantity - 1
                                                )
                                            }
                                        >
                                            <FaMinus />
                                        </button>

                                        <span>
                                            {cartItem.quantity}
                                        </span>

                                        <button
                                            type="button"
                                            disabled={
                                                updatingItemId === cartItem.id
                                            }
                                            onClick={() =>
                                                updateQuantity(
                                                    cartItem,
                                                    cartItem.quantity + 1
                                                )
                                            }
                                        >
                                            <FaPlus />
                                        </button>
                                    </div>

                                    <button
                                        type="button"
                                        className="remove-cart-item-button"
                                        disabled={
                                            updatingItemId === cartItem.id
                                        }
                                        onClick={() =>
                                            removeCartItem(cartItem.id)
                                        }
                                    >
                                        <FaTrashCan />
                                        Remove
                                    </button>
                                </div>

                                {stockErrors[cartItem.id] && (
                                    <p className="cart-stock-error">
                                        {stockErrors[cartItem.id]}
                                    </p>
                                )}
                            </div>

                            <p className="cart-item-total">
                                $
                                {Number(
                                    cartItem.productPrice *
                                    cartItem.quantity
                                ).toFixed(2)}
                            </p>
                        </article>
                    ))}
                </div>

                <aside className="cart-summary">
                    <h2>Order Summary</h2>

                    <div className="cart-summary-row">
                        <span>Items</span>
                        <span>{cartItems.length}</span>
                    </div>

                    <div className="cart-summary-total">
                        <span>Total</span>
                        <strong>
                            ${totalAmount.toFixed(2)}
                        </strong>
                    </div>

                    <button
                        type="button"
                        className="checkout-button"
                        onClick={() => navigate("/checkout")}
                    >
                        Proceed to Checkout
                    </button>
                </aside>
            </div>
        </section>
    );
}

export default CartPage;