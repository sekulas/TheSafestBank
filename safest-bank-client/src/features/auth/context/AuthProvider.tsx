import { ReactNode, useContext, useState } from 'react';
import AuthContext, { IAuthContext } from './AuthContext';
import API_ENDPOINTS, { ILoginRequest } from '../../../services/TheSafestBankApi/safestBankServerApiEndpoints';
import ModalContext from '../../modal/context/ModalContext';
import { Navigate } from 'react-router-dom';

const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [clientId, setClientId] = useState("");
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const { openModal, openSpinner, closeSpinner } = useContext(ModalContext);

  const login = async (clientNumber: string, password: string) => {
    try {
      openSpinner();
      const requestBody: ILoginRequest = { clientNumber: clientNumber, password: password };

      const response = await fetch(API_ENDPOINTS.LOGIN, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
        credentials: 'include',
      });

      const data = await response.json();
      console.log(data);

      if (!response.ok) {
        openModal('Error', `Failed to log in. ${data.title}`);
        throw new Error(`Failed to log in: ${data.title}`);
      }

      setIsAuthenticated(true);
      setClientId(data.clientId);
      setName(data.name);
      setSurname(data.surname);
      <Navigate to="/" />
    } catch (error) {
      console.error(error);
    }
    finally {
      closeSpinner();
    }
  }

  const logout = async () => {
    try {
      openSpinner();
      fetch(API_ENDPOINTS.LOGOUT, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        credentials: 'include',
      });

      setIsAuthenticated(false);
      setClientId('');
      setName('');
      setSurname('');
      <Navigate to="/login" />
    } catch (error) {
      console.error(error);
    }
    finally {
      closeSpinner();
    }
  }

  const contextValue: IAuthContext = {
    isAuthenticated,
    clientId,
    name,
    surname,
    login,
    logout,
  };


  return (
    <AuthContext.Provider value={contextValue}>
      {children}
    </AuthContext.Provider>
  );
}

export default AuthProvider;