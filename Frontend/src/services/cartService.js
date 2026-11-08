export function createCartService(client) {
    return {
        async getMyCart() {
            const response = await client.get("/cartitems");

            return response.data;
        },

        async addItem(productId, quantity) {
            const response = await client.post("/cartitems", {
                productId,
                quantity
            });

            return response.data;
        },

        async updateQuantity(cartItemId, quantity) {
            const response = await client.put(
                `/cartitems/${cartItemId}`,
                {
                    quantity
                }
            );

            return response.data;
        },

        async removeItem(cartItemId) {
            await client.delete(`/cartitems/${cartItemId}`);
        },

        async clearCart() {
            await client.delete("/cartitems/clear");
        }
    };
}