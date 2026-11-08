import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { FaArrowLeft, FaBoxOpen } from "react-icons/fa6";
import { toast } from "react-toastify";
import { useApi } from "../context/ApiContext";
import "./OrderDetailsPage.css";

function OrderDetailsPage() {
    const { orderId } = useParams();
    const { orders: orderService } = useApi();

    const [order, setOrder] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        async function loadOrderDetails() {
            try {
                setLoading(true);
                setError("");

                const orderData = await orderService.getById(orderId);

                setOrder(orderData);
            } catch (requestError) {
                const message =
                    requestError.message ||
                    "Unable to load order details.";

                setError(message);
                toast.error(message);
            } finally {
                setLoading(false);
            }
        }

        loadOrderDetails();
    }, [orderId, orderService]);

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

    function getStatusClass(status) {
        return status
            ? `order-details-status ${status.toLowerCase()}`
            : "order-details-status";
    }

    if (loading) {
        return (
            <p className="order-details-message">
                Loading order details...
            </p>
        );
    }

    if (error || !order) {
        return (
            <section className="order-details-error">
                <p>{error || "Order not found."}</p>

                <Link to="/orders" className="order-details-back-button">
                    <FaArrowLeft />
                    Back to My Orders
                </Link>
            </section>
        );
    }

    return (
        <section className="order-details-page">
            <Link to="/orders" className="order-details-back-button">
                <FaArrowLeft />
                Back to My Orders
            </Link>

            <div className="order-details-header">
                <div>
                    <p className="order-details-eyebrow">
                        ORDER DETAILS
                    </p>

                    <h1>{order.orderNumber}</h1>

                    <p className="order-details-date">
                        Placed on {formatDate(order.createdAt)}
                    </p>
                </div>

                <span className={getStatusClass(order.status)}>
                    {order.status}
                </span>
            </div>

            <div className="order-details-info-grid">
                <section className="order-details-info-card">
                    <h2>Shipping Address</h2>

                    <p>
                        {order.shippingAddress ||
                            "Shipping address not available."}
                    </p>
                </section>

                <section className="order-details-info-card">
                    <h2>Order Total</h2>

                    <p className="order-details-total">
                        ${Number(order.totalAmount).toFixed(2)}
                    </p>
                </section>
            </div>

            <section className="order-items-section">
                <div className="order-items-heading">
                    <FaBoxOpen />

                    <h2>Order Items</h2>
                </div>

                {!order.orderItems || order.orderItems.length === 0 ? (
                    <p className="order-details-message">
                        No order items found.
                    </p>
                ) : (
                    <div className="order-items-table">
                        <div className="order-items-table-header">
                            <span>Product</span>
                            <span>Price</span>
                            <span>Quantity</span>
                            <span>Total</span>
                        </div>

                        {order.orderItems.map((item) => (
                            <div
                                className="order-item-row"
                                key={item.id}
                            >
                                <span className="order-item-name">
                                    {item.productName}
                                </span>

                                <span>
                                    ${Number(item.unitPrice).toFixed(2)}
                                </span>

                                <span>{item.quantity}</span>

                                <strong>
                                    $
                                    {Number(
                                        item.unitPrice * item.quantity
                                    ).toFixed(2)}
                                </strong>
                            </div>
                        ))}
                    </div>
                )}
            </section>

            <div className="order-details-final-total">
                <span>Total Amount</span>

                <strong>
                    ${Number(order.totalAmount).toFixed(2)}
                </strong>
            </div>
        </section>
    );
}

export default OrderDetailsPage;