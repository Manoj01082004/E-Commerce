export function createAuthService(client) {
    return {
        async register(userData) {
            const response = await client.post("/users/register", userData);

            return response.data;
        },

        async login(email, password) {
            const response = await client.post("/users/login", {
                email,
                passwordHash: password
            });

            return response.data.user ?? response.data;
        },

        async logout() {
            await client.post("/users/logout");
        },

        async getMyProfile() {
            const response = await client.get("/users/me");

            return response.data;
        }
    };
}