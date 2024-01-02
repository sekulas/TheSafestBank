import { useContext } from "react";
import { Outlet, Navigate } from "react-router-dom";
import AuthContext from "../features/auth/context/AuthContext";

const ProtectedPage = () => {
  const { isAuthenticated } = useContext(AuthContext);

  return (
    <>
      {
        isAuthenticated ? (
          <Outlet />
        ) : (
          <Navigate to="/login" />
        )
      }
    </>
  );
};

export default ProtectedPage;