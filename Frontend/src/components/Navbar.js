import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import axiosClient from "../api/axiosClient";
import {
    FaBoxOpen,
    FaCartShopping,
    FaHouse,
    FaRightFromBracket,
    FaUser,
    FaUserPlus
} from "react-icons/fa6";
import { HiOutlineClipboardDocumentList } from "react-icons/hi2";
import { useAuth } from "../context/AuthContext";

function Navbar() {
    const navigate = useNavigate();
    const { user, isLoggedIn, logout } = useAuth();

    async function handleLogout() {
       try {
         await axiosClient.post("/users/logout");

        logout();

        toast.success("Logged out successfully.");

        navigate("/");
       } catch (requestError) {
        toast.error("Unable to log out. Please try again.");
       }
}

    return (
        <header className="navbar">
            <Link to="/" className="brand">
                E-Commerce
            </Link>

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