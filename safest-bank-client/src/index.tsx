import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import reportWebVitals from "./reportWebVitals";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import AppLayout from "./layouts/AppLayout";
import ErrorPage from "./pages/ErrorPage";
import LoginPage from "./pages/LoginPage";
import ProtectedPage from "./pages/ProtectedPage";
import HomePage from "./pages/HomePage";
import AuthProvider from "./components/auth/AuthProvider";
import PasswordChangePage from "./pages/PasswordChangePage";
import ClientDetailsPage from "./pages/ClientDetailsPage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    children: [
      {
        errorElement: <ErrorPage />,
        children: [
          {
            path: "login",
            element: <LoginPage />,
          },
          {
            element: <ProtectedPage />,
            children: [
              {
                index: true,
                path: "home",
                element: <HomePage />,
                //loader: accountDetailsLoader
              },
              {
                path: "client",
                element: <ClientDetailsPage />,
                //loader: clientLoader
              },
              {
                path: "password",
                element: <PasswordChangePage />
              },
              {
                path: "logout",
                //action: logoutUser,
              },
            ]
          }
        ]
      }
    ]
  },
]);

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <React.StrictMode>
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();