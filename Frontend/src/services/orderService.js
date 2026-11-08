export function createOrderService(client) {
    return {
        async checkout(shippingAddress) {
            const response = await client.post(
                "/orders/create-from-cart",
                {
                    shippingAddress
                }
            );

            return response.data;
        },

        async getMyOrders() {
            const response = await client.get("/orders/my-orders");

            return response.data;
        },

        async getById(orderId) {
            const response = await client.get(`/orders/${orderId}`);

            return response.data;
        }
    };
}