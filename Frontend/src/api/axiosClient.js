import axios from "axios";

export class ApiError extends Error {
    constructor(message, status) {
        super(message);

        this.name = "ApiError";
        this.status = status;
    }
}

const axiosClient = axios.create({
    baseURL: process.env.REACT_APP_API_BASE_URL,
    withCredentials: true,
    headers: {
        "Content-Type": "application/json"
    }
});

function getErrorMessage(error) {
    const responseData = error.response?.data;

    if (typeof responseData === "string") {
        return responseData;
    }

    if (responseData?.message) {
        return responseData.message;
    }

    if (responseData?.title) {
        return responseData.title;
    }

    if (responseData?.errors) {
        return Object.values(responseData.errors)
            .flat()
            .join(" ");
    }

    if (!error.response) {
        return "Unable to connect to the server.";
    }

    return "Something went wrong. Please try again.";
}

axiosClient.interceptors.response.use(
    (response) => response,

    async (error) => {
        const originalRequest = error.config;
        const requestUrl = originalRequest?.url || "";

        const isAuthenticationRequest =
            requestUrl.includes("/users/login") ||
            requestUrl.includes("/users/register") ||
            requestUrl.includes("/users/refresh");

        if (
            error.response?.status === 401 &&
            originalRequest &&
            !originalRequest._retry &&
            !isAuthenticationRequest
        ) {
            originalRequest._retry = true;

            try {
                await axiosClient.post("/users/refresh");

                return axiosClient(originalRequest);
            } catch (refreshError) {
                localStorage.removeItem("user");

                window.dispatchEvent(
                    new Event("auth:session-expired")
                );

                return Promise.reject(
                    new ApiError(
                        "Your session has expired. Please login again.",
                        401
                    )
                );
            }
        }

        return Promise.reject(
            new ApiError(
                getErrorMessage(error),
                error.response?.status
            )
        );
    }
);

export default axiosClient;