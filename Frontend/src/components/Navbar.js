import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import {
    FaBoxOpen,
    FaCartShopping,
    FaHouse,
    FaMagnifyingGlass,
    FaRightFromBracket,
    FaUser,
    FaUserPlus
} from "react-icons/fa6";
import { HiOutlineClipboardDocumentList } from "react-icons/hi2";
import { useApi } from "../context/ApiContext";
import { useAuth } from "../context/AuthContext";

function Navbar() {
    const navigate = useNavigate();

    const { auth: authService } = useApi();
    const { user, isLoggedIn, logout } = useAuth();

    const [searchQuery, setSearchQuery] = useState("");

    async function handleLogout() {
        try {
            await authService.logout();
        } catch (error) {
            console.error("Logout API error:", error);
        } finally {
            logout();
            toast.success("Logged out successfully.");
            navigate("/");
        }
    }

    function handleSearch(event) {
        event.preventDefault();

        const query = searchQuery.trim();

        if (!query) {
            navigate("/products");
            return;
        }

        navigate(`/products?search=${encodeURIComponent(query)}`);

        setSearchQuery("");
    }

    return (
        <header className="navbar">
            <Link to="/" className="brand">
                E-Commerce
            </Link>

            <form
                className="navbar-search-form"
                onSubmit={handleSearch}
            >
                <input
                    type="search"
                    value={searchQuery}
                    onChange={(event) =>
                        setSearchQuery(event.target.value)
                    }
                    placeholder="Search products..."
                    maxLength="100"
                    aria-label="Search products"
                />

                <button
                    type="submit"
                    className="navbar-search-button"
                    aria-label="Search"
                >
                    <FaMagnifyingGlass />
                </button>
            </form>

            <nav className="nav-links">
                <Link to="/">
                    <FaHouse className="nav-icon" />
                    Home
                </Link>

                <Link to="/products">
                    <FaBoxOpen className="nav-icon" />
                    Products
                </Link>

                {isLoggedIn ? (
                    <>
                        <Link to="/cart">
                            <FaCartShopping className="nav-icon" />
                            Cart
                        </Link>

                        <Link to="/orders">
                            <HiOutlineClipboardDocumentList className="nav-icon" />
                            My Orders
                        </Link>

                        <span className="user-name">
                            <FaUser className="nav-icon" />
                            Hi, {user.name}
                        </span>

                        <button
                            type="button"
                            className="logout-button"
                            onClick={handleLogout}
                        >
                            <FaRightFromBracket className="nav-icon" />
                            Logout
                        </button>
                    </>
                ) : (
                    <>
                        <Link to="/login">
                            <FaUser className="nav-icon" />
                            Login
                        </Link>

                        <Link to="/register">
                            <FaUserPlus className="nav-icon" />
                            Register
                        </Link>
                    </>
                )}
            </nav>
        </header>
    );
}

export default Navbar;