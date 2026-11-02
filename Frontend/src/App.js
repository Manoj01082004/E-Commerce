import { Route, Routes } from "react-router-dom";
import Navbar from "./components/Navbar";
import ProtectedRoute from "./components/ProtectedRoute";
import PublicRoute from "./components/PublicRoute";
import HomePage from "./pages/HomePage";
import ProductsPage from "./pages/ProductsPage";
import ProductDetailsPage from "./pages/ProductDetailsPage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import CartPage from "./pages/CartPage";
import CheckoutPage from "./pages/CheckoutPage";
import OrdersPage from "./pages/OrdersPage";
import OrderDetailsPage from "./pages/OrderDetailsPage";
import "./App.css";

function App() {
    return (
        <>
            <Navbar />

            <main className="main-content">
                <Routes>
                    <Route path="/" element={<HomePage />} />

                    <Route
                        path="/products"
                        element={<ProductsPage />}
                    />

                    <Route
                        path="/products/:productId"
                        element={<ProductDetailsPage />}
                    />

                    {/* Accessible only when user is NOT logged in */}
                    <Route
                        path="/login"
                        element={
                            <PublicRoute>
                                <LoginPage />
                            </PublicRoute>
                        }
                    />

                    <Route
                        path="/register"
                        element={
                            <PublicRoute>
                                <RegisterPage />
                            </PublicRoute>
                        }
                    />

                    {/* Accessible only after login */}
                    <Route
                        path="/cart"
                        element={
                            <ProtectedRoute>
                                <CartPage />
                            </ProtectedRoute>
                        }
                    />

                    <Route
                        path="/checkout"
                        element={
                            <ProtectedRoute>
                                <CheckoutPage />
                            </ProtectedRoute>
                        }
                    />

                    <Route
                        path="/orders"
                        element={
                            <ProtectedRoute>
                                <OrdersPage />
                            </ProtectedRoute>
                        }
                    />

                    <Route
                        path="/orders/:orderId"
                        element={
                            <ProtectedRoute>
                                <OrderDetailsPage />
                            </ProtectedRoute>
                        }
                    />
                </Routes>
            </main>
        </>
    );
}

export default App;