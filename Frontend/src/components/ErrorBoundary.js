import { Component } from "react";
import "./ErrorBoundary.css";

class ErrorBoundary extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hasError: false
        };
    }

    static getDerivedStateFromError() {
        return {
            hasError: true
        };
    }

    componentDidCatch(error, errorInfo) {
        console.error("React application error:", error);
        console.error("React error details:", errorInfo);
    }

    render() {
        if (this.state.hasError) {
            return (
                <main className="error-boundary">
                    <section className="error-boundary-card">
                        <h1>Something went wrong</h1>

                        <p>
                            An unexpected error occurred. Please refresh the
                            page and try again.
                        </p>

                        <button
                            type="button"
                            onClick={() => window.location.reload()}
                        >
                            Refresh Page
                        </button>
                    </section>
                </main>
            );
        }

        return this.props.children;
    }
}

export default ErrorBoundary;