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

const router = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    children: [
      {
        errorElement: <ErrorPage />,
        children: [
          {
            path: "/login",
            element: <LoginPage />
          },
          // {
          //   index: true,
          //   path: "/home",
          //   element: <HomePage />,
          //   loader: accountDetailsLoader
          // },
          // {
          //   path: "/password",
          //   element: <ChangePasswordPage />
          // },
          // {
          //   path: "/client/:clientId",
          //   element: <ClientDetailsPage />,
          //   loader: clientLoader
          // }
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
    <RouterProvider router={router} />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
