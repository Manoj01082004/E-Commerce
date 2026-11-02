import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import axiosClient from "../api/axiosClient";
import "./AuthPage.css";

function RegisterPage() {
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        name: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    const [loading, setLoading] = useState(false);

    function handleChange(event) {
        const { name, value } = event.target;

        setFormData((currentData) => ({
            ...currentData,
            [name]: value
        }));
    }

    async function handleSubmit(event) {
        event.preventDefault();

        if (formData.password !== formData.confirmPassword) {
            toast.error("Passwords do not match.");
            return;
        }

        if (formData.password.length < 6) {
            toast.error("Password must contain at least 6 characters.");
            return;
        }

        try {
            setLoading(true);

            await axiosClient.post("/users/register", {
                name: formData.name.trim(),
                email: formData.email.trim(),
                passwordHash: formData.password
            });

            toast.success("Account created successfully.");

            setTimeout(() => {
                navigate("/");
            }, 1000);
        } catch (requestError) {
            toast.error(
                requestError.response?.data ||
                "Unable to create your account."
            );
        } finally {
            setLoading(false);
        }
    }

    return (
        <main className="auth-page">
            <form className="auth-form" onSubmit={handleSubmit}>
                <h1>Create Account</h1>

                <p className="auth-subtitle">
                    Enter your details to create an account.
                </p>

                <label className="auth-label">
                    Name
                    <input
                        type="text"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        placeholder="Enter your name"
                        maxLength="100"
                        required
                    />
                </label>

                <label className="auth-label">
                    Email
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        placeholder="Enter your email"
                        required
                    />
                </label>

                <label className="auth-label">
                    Password
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        placeholder="Enter your password"
                        minLength="6"
                        required
                    />
                </label>

                <label className="auth-label">
                    Confirm Password
                    <input
                        type="password"
                        name="confirmPassword"
                        value={formData.confirmPassword}
                        onChange={handleChange}
                        placeholder="Confirm your password"
                        minLength="6"
                        required
                    />
                </label>

                <button
                    type="submit"
                    className="auth-submit-button"
                    disabled={loading}
                >
                    {loading ? "Creating Account..." : "Register"}
                </button>

                <p className="auth-footer-text">
                    Already have an account?{" "}
                    <Link to="/login">Login</Link>
                </p>
            </form>
        </main>
    );
}

export default RegisterPage;