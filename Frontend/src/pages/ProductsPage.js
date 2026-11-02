import { useEffect, useState } from "react";
import { useNavigate, useSearchParams } from "react-router-dom";
import { toast } from "react-toastify";
import axiosClient from "../api/axiosClient";
import { useAuth } from "../context/AuthContext";
import ProductCard from "../components/ProductCard";
import "./ProductsPage.css";

function ProductsPage() {
    const navigate = useNavigate();
    const [searchParams, setSearchParams] = useSearchParams();
    const { isLoggedIn } = useAuth();

    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    const selectedCategoryId = searchParams.get("categoryId") || "";

    useEffect(() => {
        loadPageData();
    }, []);

    async function loadPageData() {
        try {
            const [productsResponse, categoriesResponse] = await Promise.all([
                axiosClient.get("/products"),
                axiosClient.get("/categories")
            ]);

            setProducts(productsResponse.data);
            setCategories(categoriesResponse.data);
        } catch (requestError) {
            console.error("Unable to load products:", requestError);

            setError(
                requestError.response?.data ||
                "Unable to load products. Please try again."
            );
        } finally {
            setLoading(false);
        }
    }

    function handleCategoryChange(event) {
        const categoryId = event.target.value;

        if (!categoryId) {
            setSearchParams({});
            return;
        }

        setSearchParams({
            categoryId
        });
    }

    function getIncludedCategoryIds() {
        if (!selectedCategoryId) {
            return [];
        }

        const categoryId = Number(selectedCategoryId);

        const childCategoryIds = categories
            .filter((category) => {
                return category.parentCategoryId === categoryId;
            })
            .map((category) => category.id);

        return [categoryId, ...childCategoryIds];
    }

    const includedCategoryIds = getIncludedCategoryIds();

    const visibleProducts = products.filter((product) => {
        if (!product.isActive) {
            return false;
        }

        if (!selectedCategoryId) {
            return true;
        }

        return includedCategoryIds.includes(product.categoryId);
    });

    async function handleAddToCart(product) {
        if (!isLoggedIn) {
            toast.info("Please login before adding items to your cart.");

            navigate("/login");

            return;
        }

        try {
            await axiosClient.post("/cartitems", {
                productId: product.productId,
                quantity: 1
            });

            toast.success(`${product.name} added to cart.`);
        } catch (requestError) {
            toast.error(
                requestError.response?.data ||
                "Unable to add product to cart."
            );
        }
    }

    if (loading) {
        return (
            <p className="products-message">
                Loading products...
            </p>
        );
    }

    if (error) {
        return (
            <p className="products-error">
                {error}
            </p>
        );
    }

    return (
        <section className="products-page">
            <div className="products-page-header">
                <div>
                    <p className="products-eyebrow">
                        EXPLORE OUR COLLECTION
                    </p>

                    <h1>Products</h1>

                    <p className="products-count">
                        {visibleProducts.length} product
                        {visibleProducts.length !== 1 ? "s" : ""} found
                    </p>
                </div>

                <label className="category-select-label">
                    Category

                    <select
                        value={selectedCategoryId}
                        onChange={handleCategoryChange}
                    >
                        <option value="">All Categories</option>

                        {categories
                            .filter((category) => category.isActive)
                            .sort((firstCategory, secondCategory) => {
                                return (
                                    firstCategory.displayOrder -
                                    secondCategory.displayOrder
                                );
                            })
                            .map((category) => (
                                <option
                                    key={category.id}
                                    value={category.id}
                                >
                                    {category.parentCategoryId
                                        ? `— ${category.name}`
                                        : category.name}
                                </option>
                            ))}
                    </select>
                </label>
            </div>

            {visibleProducts.length === 0 ? (
                <div className="no-products">
                    <h2>No products found</h2>
                    <p>Try choosing a different category.</p>
                </div>
            ) : (
                <div className="products-grid">
                    {visibleProducts.map((product) => (
                        <ProductCard
                            key={product.productId}
                            product={product}
                            onAddToCart={handleAddToCart}
                        />
                    ))}
                </div>
            )}
        </section>
    );
}

export default ProductsPage;