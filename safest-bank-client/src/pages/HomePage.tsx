import { useContext, useEffect } from "react";
import API_ENDPOINTS from "../services/TheSafestBankApi/safestBankServerApiEndpoints";
import ModalContext from "../features/modal/context/ModalContext";
import AuthContext from "../features/auth/context/AuthContext";
import TransactionMenu from "../features/transactions/components/TransactionMenu";
import TransactionList from "../features/transactions/components/TransactionList";

const HomePage = () => {
  const { openModal, openSpinner, closeSpinner } = useContext(ModalContext);
  const { setClientData, logout } = useContext(AuthContext);

  useEffect(() => {
    const fetchData = async () => {
      try {
        openSpinner();

        const response = await fetch(API_ENDPOINTS.GET_CLIENT, {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
          credentials: "include",
        });

        const data = await response.json();

        if (!response.ok) {
          if (response.status === 401) {
            logout();
          }
          throw new Error(`Failed to get the client data. ${data.message}`);
        }

        setClientData(data);

      } catch (error) {
        handleError((error as Error).message);
      } finally {
        closeSpinner();
      }
    };

    fetchData();
  }, []);

  const handleError = (message: string) => {
    openModal("Error", `${message}`);
    logout();
  };

  return (
    <div id="home-page">
      <TransactionMenu />
      <TransactionList />
    </div>
  );
};

export default HomePage;
