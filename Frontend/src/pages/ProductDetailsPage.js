import { useCallback, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { FaCartShopping, FaMinus, FaPlus } from "react-icons/fa6";
import { toast } from "react-toastify";
import axiosClient from "../api/axiosClient";
import { useAuth } from "../context/AuthContext";
import "./ProductDetailsPage.css";

const fallbackImage =
    "https://placehold.co/700x600/222c3d/ddb3a3?text=Product";

function ProductDetailsPage() {
    const { productId } = useParams();
    const navigate = useNavigate();
    const { isLoggedIn } = useAuth();

    const [product, setProduct] = useState(null);
    const [quantity, setQuantity] = useState(1);
    const [loading, setLoading] = useState(true);
    const [addingToCart, setAddingToCart] = useState(false);
    const [error, setError] = useState("");

    const loadProduct = useCallback(async () => {
        try {
            setLoading(true);
            setError("");

            const response = await axiosClient.get(`/products/${productId}`);

            setProduct(response.data);
        } catch (requestError) {
            setError(
                requestError.response?.data ||
                "Unable to load product details."
            );
        } finally {
            setLoading(false);
        }
    }, [productId]);

    useEffect(() => {
        loadProduct();
    }, [loadProduct]);

    function decreaseQuantity() {
        if (quantity > 1) {
            setQuantity(quantity - 1);
        }
    }

    function increaseQuantity() {
        if (quantity < 10) {
            setQuantity(quantity + 1);
        }
    }

    async function handleAddToCart() {
        if (!isLoggedIn) {
            toast.info("Please login before adding items to your cart.");

            navigate("/login");

            return;
        }

        try {
            setAddingToCart(true);

            await axiosClient.post("/cartitems", {
                productId: product.productId,
                quantity
            });

            toast.success(`${product.name} added to cart.`);
        } catch (requestError) {
            toast.error(
                requestError.response?.data ||
                "Unable to add product to cart."
            );
        } finally {
            setAddingToCart(false);
        }
    }

    if (loading) {
        return (
            <p className="product-details-message">
                Loading product details...
            </p>
        );
    }

    if (error) {
        return (
            <section className="product-details-error">
                <p>{error}</p>

                <Link to="/products" className="back-button">
                    ← Back to Products
                </Link>
            </section>
        );
    }

    if (!product) {
        return null;
    }

    return (
        <section className="product-details-page">
            <Link to="/products" className="back-button">
                ← Back to Products
            </Link>

            <div className="product-details-card">
                <div className="product-details-image-panel">
                    <img
                        src={product.imageUrl || fallbackImage}
                        alt={product.name}
                        className="product-details-image"
                        onError={(event) => {
                            event.currentTarget.src = fallbackImage;
                        }}
                    />
                </div>

                <div className="product-details-content">
                    <p className="product-details-label">
                        PRODUCT DETAILS
                    </p>

                    <h1>{product.name}</h1>

                    <p className="product-details-price">
                        ${Number(product.price).toFixed(2)}
                    </p>

                    <div className="product-details-description">
                        <h2>Description</h2>

                        <p>
                            {product.description ||
                                "No description available for this product."}
                        </p>
                    </div>

                    <div className="quantity-section">
                        <p className="quantity-label">Quantity</p>

                        <div className="quantity-selector">
                            <button
                                type="button"
                                onClick={decreaseQuantity}
                                disabled={quantity === 1}
                                aria-label="Decrease quantity"
                            >
                                <FaMinus />
                            </button>

                            <span>{quantity}</span>

                            <button
                                type="button"
                                onClick={increaseQuantity}
                                disabled={quantity === 10}
                                aria-label="Increase quantity"
                            >
                                <FaPlus />
                            </button>
                        </div>

                        <p className="quantity-note">
                            You can add up to 10 units at a time.
                        </p>
                    </div>

                    <button
                        type="button"
                        className="product-details-cart-button"
                        onClick={handleAddToCart}
                        disabled={addingToCart}
                    >
                        <FaCartShopping />
                        {addingToCart
                            ? "Adding to Cart..."
                            : "Add to Cart"}
                    </button>
                </div>
            </div>
        </section>
    );
}

export default ProductDetailsPage;