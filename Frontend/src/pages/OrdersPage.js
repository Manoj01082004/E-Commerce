import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { FaBoxOpen } from "react-icons/fa6";
import { toast } from "react-toastify";
import axiosClient from "../api/axiosClient";
import "./OrdersPage.css";

function OrdersPage() {
    const [orders, setOrders] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadOrders();
    }, []);

    async function loadOrders() {
        try {
            const response = await axiosClient.get("/orders/my-orders");

            setOrders(response.data);
        } catch (requestError) {
            const status = requestError.response?.status;

            if (status !== 404) {
                toast.error(
                    requestError.response?.data ||
                    "Unable to load your orders."
                );
            }

            setOrders([]);
        } finally {
            setLoading(false);
        }
    }

    function getStatusClass(status) {
        return status
            ? `order-status ${status.toLowerCase()}`
            : "order-status";
    }

    function formatDate(dateValue) {
        if (!dateValue) {
            return "Not available";
        }

        return new Date(dateValue).toLocaleDateString("en-US", {
            day: "2-digit",
            month: "short",
            year: "numeric"
        });
    }

    if (loading) {
        return (
            <p className="orders-message">
                Loading your orders...
            </p>
        );
    }

    if (orders.length === 0) {
        return (
            <section className="empty-orders">
                <FaBoxOpen className="empty-orders-icon" />

                <h1>No Orders Yet</h1>

                <p>
                    Your placed orders will appear here.
                </p>

                <Link to="/products" className="orders-shop-button">
                    Start Shopping
                </Link>
            </section>
        );
    }

    return (
        <section className="orders-page">
            <div className="orders-header">
                <p className="orders-eyebrow">PURCHASE HISTORY</p>

                <h1>My Orders</h1>

                <p>
                    View your orders and track their current status.
                </p>
            </div>

            <div className="orders-list">
                {orders.map((order) => (
                    <article className="order-card" key={order.id}>
                        <div className="order-main-details">
                            <p className="order-number">
                                {order.orderNumber}
                            </p>

                            <p className="order-date">
                                Placed on {formatDate(order.createdAt)}
                            </p>
                        </div>

                        <div className="order-total">
                            <span>Total Amount</span>

                            <strong>
                                ${Number(order.totalAmount).toFixed(2)}
                            </strong>
                        </div>

                        <span className={getStatusClass(order.status)}>
                            {order.status}
                        </span>

                        <Link
                            to={`/orders/${order.id}`}
                            className="order-details-button"
                        >
                            View Details →
                        </Link>
                    </article>
                ))}
            </div>
        </section>
    );
}

export default OrdersPage;