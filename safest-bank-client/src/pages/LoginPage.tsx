import { useState, ChangeEvent, useContext } from 'react';
import { Navigate } from 'react-router-dom';
import AuthContext from '../features/auth/context/AuthContext';
import API_ENDPOINTS, { IFetchPasswordMaskRequest } from '../services/TheSafestBankApi/safestBankServerApiEndpoints';
import PartialPasswordForm from '../features/auth/PartialPasswordForm';
import ModalContext from '../features/modal/context/ModalContext';
import Modal from '../features/modal/Modal';

const LoginPage = () => {
  const [clientNumber, setClientNumber] = useState<string>('');
  const [passwordMask, setPasswordMask] = useState<number[] | null>(null);
  const { isAuthenticated, login } = useContext(AuthContext);
  const { openModal } = useContext(ModalContext);

  const handleSubmitClientNumber = async () => {
    try {
      const requestBody: IFetchPasswordMaskRequest = { clientNumber: clientNumber };

      const response = await fetch(API_ENDPOINTS.FETCH_PASSWORD_MASK, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
      });

      const data = await response.json();

      if (!response.ok) {
        openModal('Error', `Failed to fetch password combination. ${data.message}`);
        throw new Error(`Failed to fetch password combination: ${data.message}`);
      }

      setPasswordMask(data);
      console.log(data);
    } catch (error) {
      console.error(error);
    }
  };

  const handleClientNumberChange = async (event: ChangeEvent<HTMLInputElement>) => {
    setClientNumber(event.target.value);
  };

  const handleLogin = async (password: string) => {
    login(clientNumber, password);
  };

  return (
    <>
      {
        isAuthenticated ? (
          <Navigate to="/" />
        )
          : (
            <div id="login-page">
              <h1>Login</h1>
              {!passwordMask && (
                <>
                  <h3>Provide the client number:</h3>
                  <input
                    type="text"
                    placeholder="Client number"
                    value={clientNumber}
                    onChange={handleClientNumberChange}
                  />
                  <br />
                  <button className="main-action-button" onClick={handleSubmitClientNumber}>Submit Client Number</button>
                </>
              )}
              <Modal />
              {passwordMask && (
                <>
                  <h3>Provide the following letters of the password for the client with number: "{clientNumber}"</h3>
                  <PartialPasswordForm
                    mask={passwordMask}
                    onSubmit={handleLogin}
                  />
                </>
              )}
            </div>
          )
      }
    </>
  );
}

export default LoginPage;