import {
    createContext,
    useContext,
    useEffect,
    useState
} from "react";

const AuthContext = createContext();

export function AuthProvider({ children }) {
    const [user, setUser] = useState(() => {
        const savedUser = localStorage.getItem("user");

        return savedUser ? JSON.parse(savedUser) : null;
    });

    function login(loggedInUser) {
        localStorage.setItem(
            "user",
            JSON.stringify(loggedInUser)
        );

        setUser(loggedInUser);
    }

    function logout() {
        localStorage.removeItem("user");

        setUser(null);
    }

    useEffect(() => {
        function handleSessionExpired() {
            localStorage.removeItem("user");

            setUser(null);

            window.location.assign("/login");
        }

        window.addEventListener(
            "auth:session-expired",
            handleSessionExpired
        );

        return () => {
            window.removeEventListener(
                "auth:session-expired",
                handleSessionExpired
            );
        };
    }, []);

    return (
        <AuthContext.Provider
            value={{
                user,
                login,
                logout,
                isLoggedIn: Boolean(user)
            }}
        >
            {children}
        </AuthContext.Provider>
    );
}

export function useAuth() {
    const auth = useContext(AuthContext);

    if (!auth) {
        throw new Error(
            "useAuth must be used inside AuthProvider."
        );
    }

    return auth;
}