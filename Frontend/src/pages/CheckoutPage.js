import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { FaArrowLeft, FaLock } from "react-icons/fa6";
import { toast } from "react-toastify";
import { useApi } from "../context/ApiContext";
import "./CheckoutPage.css";

function CheckoutPage() {
    const navigate = useNavigate();

    const {
        cart: cartService,
        orders: orderService
    } = useApi();

    const [cartItems, setCartItems] = useState([]);
    const [shippingAddress, setShippingAddress] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [loading, setLoading] = useState(true);
    const [placingOrder, setPlacingOrder] = useState(false);

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

    function getTotalAmount() {
        return cartItems.reduce((total, cartItem) => {
            return total + (
                cartItem.productPrice *
                cartItem.quantity
            );
        }, 0);
    }

    async function handlePlaceOrder(event) {
        event.preventDefault();

        if (!shippingAddress.trim()) {
            toast.error("Shipping address is required.");
            return;
        }

        if (!phoneNumber.trim()) {
            toast.error("Phone number is required.");
            return;
        }

        try {
            setPlacingOrder(true);

            const order = await orderService.checkout(
                shippingAddress.trim()
            );

            toast.success("Order placed successfully.");

            navigate(`/orders/${order.id}`);
        } catch (error) {
            toast.error(
                error.message ||
                "Unable to place your order."
            );
        } finally {
            setPlacingOrder(false);
        }
    }

    if (loading) {
        return (
            <p className="checkout-message">
                Loading checkout...
            </p>
        );
    }

    if (cartItems.length === 0) {
        return (
            <section className="checkout-empty-cart">
                <h1>Your Cart is Empty</h1>

                <p>
                    Add products to your cart before proceeding
                    to checkout.
                </p>

                <Link
                    to="/products"
                    className="checkout-shop-button"
                >
                    Continue Shopping
                </Link>
            </section>
        );
    }

    return (
        <section className="checkout-page">
            <Link to="/cart" className="checkout-back-link">
                <FaArrowLeft />
                Back to Cart
            </Link>

            <div className="checkout-header">
                <p className="checkout-eyebrow">
                    SECURE CHECKOUT
                </p>

                <h1>Checkout</h1>
            </div>

            <div className="checkout-layout">
                <form
                    className="checkout-form"
                    onSubmit={handlePlaceOrder}
                >
                    <h2>Shipping Details</h2>

                    <label className="checkout-label">
                        Shipping Address

                        <textarea
                            value={shippingAddress}
                            onChange={(event) =>
                                setShippingAddress(event.target.value)
                            }
                            placeholder="Enter your full shipping address"
                            maxLength="500"
                            rows="5"
                            required
                        />
                    </label>

                    <label className="checkout-label">
                        Phone Number

                        <input
                            type="tel"
                            value={phoneNumber}
                            onChange={(event) =>
                                setPhoneNumber(event.target.value)
                            }
                            placeholder="Enter your phone number"
                            maxLength="20"
                            required
                        />
                    </label>

                    <p className="checkout-note">
                        Phone number is collected for delivery contact.
                    </p>

                    <button
                        type="submit"
                        className="place-order-button"
                        disabled={placingOrder}
                    >
                        <FaLock />

                        {placingOrder
                            ? "Placing Order..."
                            : "Place Order"}
                    </button>
                </form>

                <aside className="checkout-summary">
                    <h2>Order Summary</h2>

                    <div className="checkout-summary-items">
                        {cartItems.map((cartItem) => (
                            <div
                                className="checkout-summary-item"
                                key={cartItem.id}
                            >
                                <div>
                                    <p>{cartItem.productName}</p>

                                    <span>
                                        $
                                        {Number(
                                            cartItem.productPrice
                                        ).toFixed(2)}
                                        {" × "}
                                        {cartItem.quantity}
                                    </span>
                                </div>

                                <strong>
                                    $
                                    {Number(
                                        cartItem.productPrice *
                                        cartItem.quantity
                                    ).toFixed(2)}
                                </strong>
                            </div>
                        ))}
                    </div>

                    <div className="checkout-total">
                        <span>Total Amount</span>

                        <strong>
                            ${getTotalAmount().toFixed(2)}
                        </strong>
                    </div>
                </aside>
            </div>
        </section>
    );
}

export default CheckoutPage;