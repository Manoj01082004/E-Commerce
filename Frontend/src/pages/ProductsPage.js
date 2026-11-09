import { useEffect, useState } from "react";
import { useNavigate, useSearchParams } from "react-router-dom";
import { toast } from "react-toastify";
import ProductCard from "../components/ProductCard";
import { useApi } from "../context/ApiContext";
import { useAuth } from "../context/AuthContext";
import "./ProductsPage.css";

function ProductsPage() {
    const navigate = useNavigate();
    const [searchParams, setSearchParams] = useSearchParams();

    const { isLoggedIn } = useAuth();

    const {
        products: productService,
        categories: categoryService,
        cart: cartService
    } = useApi();

    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    const [searching, setSearching] = useState(false);
    const [error, setError] = useState("");

    const selectedCategoryId =
        searchParams.get("categoryId") || "";

    const searchQuery =
        searchParams.get("search") || "";

    useEffect(() => {
        async function loadCategories() {
            try {
                const categoryData = await categoryService.getAll();

                setCategories(categoryData);
            } catch (requestError) {
                setError(
                    requestError.message ||
                    "Unable to load categories."
                );
            }
        }

        loadCategories();
    }, [categoryService]);

    useEffect(() => {
        async function loadProducts() {
            try {
                setLoading(true);
                setError("");

                let productData;

                if (searchQuery.trim()) {
                    setSearching(true);

                    productData = await productService.search(
                        searchQuery.trim()
                    );
                } else {
                    productData = await productService.getAll();
                }

                setProducts(productData);
            } catch (requestError) {
                setError(
                    requestError.message ||
                    "Unable to load products."
                );
            } finally {
                setLoading(false);
                setSearching(false);
            }
        }

        loadProducts();
    }, [searchQuery, productService]);

    function handleCategoryChange(event) {
        const categoryId = event.target.value;

        const updatedSearchParams = new URLSearchParams();

        if (searchQuery) {
            updatedSearchParams.set("search", searchQuery);
        }

        if (categoryId) {
            updatedSearchParams.set("categoryId", categoryId);
        }

        setSearchParams(updatedSearchParams);
    }

    function getIncludedCategoryIds() {
        if (!selectedCategoryId) {
            return [];
        }

        const categoryId = Number(selectedCategoryId);

        const childCategoryIds = categories
            .filter((category) =>
                category.parentCategoryId === categoryId
            )
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
            await cartService.addItem(product.productId, 1);

            toast.success(`${product.name} added to cart.`);
        } catch (requestError) {
            toast.error(
                requestError.message ||
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

                    {searchQuery && (
                        <p className="products-search-text">
                            Search results for: <strong>{searchQuery}</strong>
                        </p>
                    )}

                    <p className="products-count">
                        {visibleProducts.length} product
                        {visibleProducts.length !== 1 ? "s" : ""} found
                    </p>
                </div>

                <div className="products-filters">
                    <label className="category-select-label">
                        Category

                        <select
                            value={selectedCategoryId}
                            onChange={handleCategoryChange}
                        >
                            <option value="">All Categories</option>

                            {categories
                                .filter((category) => category.isActive)
                                .sort(
                                    (firstCategory, secondCategory) =>
                                        firstCategory.displayOrder -
                                        secondCategory.displayOrder
                                )
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
            </div>

            {searching && (
                <p className="searching-message">
                    Searching products...
                </p>
            )}

            {visibleProducts.length === 0 ? (
                <div className="no-products">
                    <h2>No products found</h2>

                    <p>
                        Try another search word or choose a different category.
                    </p>
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