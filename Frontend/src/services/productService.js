export function createProductService(client) {
    return {
        async getAll() {
            const response = await client.get("/products");

            return response.data;
        },

        async getById(productId) {
            const response = await client.get(
                `/products/${productId}`
            );

            return response.data;
        },

        async search(searchQuery) {
            const response = await client.get("/products/search", {
                params: {
                    query: searchQuery
                }
            });

            return response.data;
        }
    };
}