export function createCategoryService(client) {
    return {
        async getAll() {
            const response = await client.get("/categories");
            return response.data;
        }
    };
}