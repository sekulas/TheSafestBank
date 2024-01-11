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
import AuthProvider from "./features/auth/context/AuthProvider";
import PasswordResetPage from "./pages/PasswordResetPage";
import ClientDetailsPage from "./pages/ClientDetailsPage";
import ModalProvider from "./features/modal/context/ModalProvider";

const router = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    errorElement: <ErrorPage />,
    children: [

      {
        path: "login",
        element: <LoginPage />,
      },
      {
        path: "password-reset",
        element: <PasswordResetPage />
      },
      {
        element: <ProtectedPage />,
        children: [
          {
            index: true,
            element: <HomePage />,
          },
          {
            path: "client",
            element: <ClientDetailsPage />,
          },

        ]
      }
    ]
  }
]);

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <React.StrictMode>
    <ModalProvider>
      <AuthProvider>
        <RouterProvider router={router} />
      </AuthProvider>
    </ModalProvider>
  </React.StrictMode>
);


//TODO - TO REMOVE
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
