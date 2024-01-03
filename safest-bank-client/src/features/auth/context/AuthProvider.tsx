import { ReactNode, useContext, useState } from 'react';
import AuthContext, { IAddress, IAuthContext, IBankClient, IIdentityCard, ITransaction } from './AuthContext';
import API_ENDPOINTS, { ILoginRequest } from '../../../services/TheSafestBankApi/safestBankServerApiEndpoints';
import ModalContext from '../../modal/context/ModalContext';
import { Navigate } from 'react-router-dom';

const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [clientNumber, setClientNumber] = useState("");
  const [accountNumber, setAccountNumber] = useState("");
  const [balance, setBalance] = useState(0);
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [pesel, setPesel] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState<IAddress>({ country: "", city: "", street: "", houseNumber: "", zipCode: "" });
  const [identityCard, setIdentityCard] = useState<IIdentityCard>({ type: "", serie: "", number: "", countryOfIssue: "" });
  const [transactions, setTransactions] = useState<ITransaction[]>([]);

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

      if (!response.ok) {
        const data = await response.json();
        openModal('Error', `Failed to log in. ${data.message}`);
        throw new Error(`Failed to log in: ${data.message}`);
      }

      setIsAuthenticated(true);
      console.log('Logged in successfully!');
      console.log(response);
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
      setClientData(null);
      <Navigate to="/login" />
    } catch (error) {
      console.error(error);
    }
    finally {
      closeSpinner();
    }
  }

  const setClientData = async (data: IBankClient | null) => {
    if (!data) {
      setIsAuthenticated(false);
      setClientNumber("");
      setAccountNumber("");
      setBalance(0);
      setName("");
      setSurname("");
      setPesel("");
      setEmail("");
      setAddress({ country: "", city: "", street: "", houseNumber: "", zipCode: "" });
      setIdentityCard({ type: "", serie: "", number: "", countryOfIssue: "" });
      setTransactions([]);
      return;
    }

    setClientNumber(data.clientNumber);
    setAccountNumber(data.accountNumber);
    setBalance(data.balance);
    setName(data.name);
    setSurname(data.surname);
    setPesel(data.pesel);
    setEmail(data.email);
    setAddress(data.address);
    setIdentityCard(data.identityCard);
    setTransactions(data.transactions);
  }

  const contextValue: IAuthContext = {
    isAuthenticated,
    clientNumber,
    accountNumber,
    balance,
    name,
    surname,
    pesel,
    email,
    address,
    identityCard,
    transactions,
    login,
    logout,
    setClientData,
    setTransactions,
  };


  return (
    <AuthContext.Provider value={contextValue}>
      {children}
    </AuthContext.Provider>
  );
}

export default AuthProvider;