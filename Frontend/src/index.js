import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import App from "./App";
import ErrorBoundary from "./components/ErrorBoundary";
import { ApiProvider } from "./context/ApiContext";
import { AuthProvider } from "./context/AuthContext";
import "react-toastify/dist/ReactToastify.css";
import "./index.css";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
    <React.StrictMode>
        <BrowserRouter>
            <AuthProvider>
                <ApiProvider>
                    <ErrorBoundary>
                        <App />
                    </ErrorBoundary>

                    <ToastContainer
                        position="top-right"
                        autoClose={3000}
                        hideProgressBar={false}
                        newestOnTop
                        pauseOnHover={false}
                        theme="dark"
                    />
                </ApiProvider>
            </AuthProvider>
        </BrowserRouter>
    </React.StrictMode>
);