import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useApi } from "../context/ApiContext";
import { useAuth } from "../context/AuthContext";
import "./AuthPage.css";

function LoginPage() {
    const navigate = useNavigate();
    const { auth: authService } = useApi();
    const { login } = useAuth();

    const [formData, setFormData] = useState({
        email: "",
        password: ""
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

        try {
            setLoading(true);

            const user = await authService.login(
                formData.email.trim(),
                formData.password
            );

            if (!user?.name) {
                throw new Error("Login response did not contain user details.");
            }

            login(user);

            toast.success(`Welcome back, ${user.name}!`);

            navigate("/");
        } catch (error) {
            toast.error(error.message || "Invalid email or password.");
        } finally {
            setLoading(false);
        }
    }

    return (
        <main className="auth-page">
            <form className="auth-form" onSubmit={handleSubmit}>
                <h1>Login</h1>

                <p className="auth-subtitle">
                    Enter your email and password to continue.
                </p>

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
                        required
                    />
                </label>

                <button
                    type="submit"
                    className="auth-submit-button"
                    disabled={loading}
                >
                    {loading ? "Logging In..." : "Login"}
                </button>

                <p className="auth-footer-text">
                    New user?{" "}
                    <Link to="/register">Create an account</Link>
                </p>
            </form>
        </main>
    );
}

export default LoginPage;