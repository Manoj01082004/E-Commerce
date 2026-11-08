import { createContext, useContext, useMemo } from "react";
import axiosClient from "../api/axiosClient";
import { createAuthService } from "../services/authService";
import { createCartService } from "../services/cartService";
import { createCategoryService } from "../services/categoryService";
import { createOrderService } from "../services/orderService";
import { createProductService } from "../services/productService";

const ApiContext = createContext(null);

export function ApiProvider({ children }) {
    const api = useMemo(
        () => ({
            auth: createAuthService(axiosClient),
            cart: createCartService(axiosClient),
            categories: createCategoryService(axiosClient),
            orders: createOrderService(axiosClient),
            products: createProductService(axiosClient)
        }),
        []
    );

    return (
        <ApiContext.Provider value={api}>
            {children}
        </ApiContext.Provider>
    );
}

export function useApi() {
    const api = useContext(ApiContext);

    if (!api) {
        throw new Error("useApi must be used inside ApiProvider.");
    }

    return api;
}