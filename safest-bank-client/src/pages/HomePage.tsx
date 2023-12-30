import { useContext, useEffect, useState } from "react";
import API_ENDPOINTS from "../services/TheSafestBankApi/safestBankServerApiEndpoints";
import ModalContext from "../features/modal/context/ModalContext";
import AuthContext from "../features/auth/context/AuthContext";

const HomePage = () => {
  const { openModal, openSpinner, closeSpinner } = useContext(ModalContext);
  const { logout } = useContext(AuthContext);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        openSpinner();
        console.log('Fetching data...')
        const response = await fetch(API_ENDPOINTS.GET_CLIENT, {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
          credentials: 'include',
        });

        const data = await response.json();
        console.log(data)
        console.log(response)
        if (!response.ok) {
          openModal('Error', `Failed to get the client data. ${data.message}`);
          logout();
          throw new Error(`Failed to get the client data: ${data.message}`);
        }

        console.log(data);

      } catch (error) {
        console.error(error);
      } finally {
        closeSpinner();
      }
    };

    fetchData();
  }, []);

  return (
    <div id="home-page">
      <h1>Home Page</h1>
    </div>
  );
}

export default HomePage;