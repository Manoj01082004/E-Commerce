import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import axiosClient from "../api/axiosClient";
import "./HomePage.css";

const fallbackImage =
    "https://placehold.co/600x500/222c3d/ddb3a3?text=Category";

function HomePage() {
    const [allCategories, setAllCategories] = useState([]);
    const [parentCategories, setParentCategories] = useState([]);
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        loadHomeData();
    }, []);

    useEffect(() => {
        console.log(products);
    }, [products])

    async function loadHomeData() {
        try {
            const categoriesResponse = await axiosClient.get("/categories");

            const categories = categoriesResponse.data;

            const parents = categories
                .filter((category) => {
                    return (
                        category.isActive &&
                        !category.parentCategoryId
                    );
                })
                .sort((firstCategory, secondCategory) => {
                    return (
                        firstCategory.displayOrder -
                        secondCategory.displayOrder
                    );
                });

            setAllCategories(categories);
            setParentCategories(parents);

            try {
                const productsResponse = await axiosClient.get("/products");

                setProducts(productsResponse.data);
            } catch (productError) {
                console.error("Unable to load products:", productError);

                setError(
                    "Categories loaded, but product images could not be loaded."
                );
            }
        } catch (categoryError) {
            console.error("Unable to load categories:", categoryError);

            setError(
                categoryError.response?.data ||
                categoryError.message ||
                "Unable to load categories."
            );
        } finally {
            setLoading(false);
        }
    }

    function getCategoryImage(parentCategoryId) {
        const subCategoryIds = allCategories
            .filter((category) => {
                return category.parentCategoryId === parentCategoryId;
            })
            .map((category) => category.id);

        const product = products.find((item) => {
            return (
                item.categoryId === parentCategoryId ||
                subCategoryIds.includes(item.categoryId)
            );
        });

        return product?.imageUrl || fallbackImage;
    }

    if (loading) {
        return (
            <p className="category-home-message">
                Loading categories...
            </p>
        );
    }

    if (parentCategories.length === 0 && error) {
        return (
            <p className="category-home-error">
                {error}
            </p>
        );
    }

    return (
        <section className="category-home">
            <div className="category-home-header">
                <div>
                    <p className="category-home-label">
                        SHOP BY CATEGORY
                    </p>

                    <h1>Categories</h1>
                </div>

                <Link to="/products" className="category-view-all">
                    View Products →
                </Link>
            </div>

            {error && (
                <p className="category-home-warning">
                    {error}
                </p>
            )}

            {parentCategories.length === 0 ? (
                <p className="category-home-message">
                    No parent categories are available.
                </p>
            ) : (
                <div className="category-home-grid">
                    {parentCategories.map((category) => (
                        <Link
                            key={category.id}
                            to={`/products?categoryId=${category.id}`}
                            className="category-home-card"
                        >
                            <img
                                src={getCategoryImage(category.id)}
                                alt={category.name}
                                className="category-home-image"
                                onError={(event) => {
                                    event.currentTarget.src = fallbackImage;
                                }}
                            />

                            <div className="category-home-overlay">
                                <h2>{category.name}</h2>

                                <p>{category.description}</p>

                                <span>
                                    Explore Category →
                                </span>
                            </div>
                        </Link>
                    ))}
                </div>
            )}
        </section>
    );
}

export default HomePage;