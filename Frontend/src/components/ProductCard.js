import { Link } from "react-router-dom";
import { FaCartShopping } from "react-icons/fa6";

const fallbackImage =
    "https://placehold.co/600x500/222c3d/ddb3a3?text=Product";

function ProductCard({ product, onAddToCart }) {
    function handleAddToCart(event) {
        event.preventDefault();
        event.stopPropagation();

        onAddToCart(product);
    }

    return (
        <article className="product-card">
            <Link
                to={`/products/${product.productId}`}
                className="product-card-link"
            >
                <div className="product-image-container">
                    <img
                        src={product.imageUrl || fallbackImage}
                        alt={product.name}
                        className="product-image"
                        onError={(event) => {
                            event.currentTarget.src = fallbackImage;
                        }}
                    />
                </div>

                <div className="product-card-content">
                    <h2>{product.name}</h2>

                    <p className="product-description">
                        {product.description || "No description available."}
                    </p>

                    <p className="product-price">
                        ${Number(product.price).toFixed(2)}
                    </p>
                </div>
            </Link>

            <button
                type="button"
                className="add-to-cart-button"
                onClick={handleAddToCart}
            >
                <FaCartShopping />
                Add to Cart
            </button>
        </article>
    );
}

export default ProductCard;