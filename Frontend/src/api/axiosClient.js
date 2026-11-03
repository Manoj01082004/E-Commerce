import axios from "axios";

const axiosClient = axios.create({
    baseURL: process.env.REACT_APP_API_BASE_URL,
    withCredentials: true,
    headers: {
        "Content-Type": "application/json"
    }
});

axiosClient.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;
        const requestUrl = originalRequest?.url || "";

        const isAuthRequest =
            requestUrl.includes("/users/login") ||
            requestUrl.includes("/users/register") ||
            requestUrl.includes("/users/refresh");

        if (
            error.response?.status === 401 &&
            originalRequest &&
            !originalRequest._retry &&
            !isAuthRequest
        ) {
            originalRequest._retry = true;

            try {
                await axiosClient.post("/users/refresh");

                return axiosClient(originalRequest);
            } catch (refreshError) {
                localStorage.removeItem("user");
                window.location.assign("/login");

                return Promise.reject(refreshError);
            }
        }

        return Promise.reject(error);
    }
);

export default axiosClient;