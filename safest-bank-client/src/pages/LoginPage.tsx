import { useState, ChangeEvent, useContext } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';
import AuthContext from '../features/auth/context/AuthContext';
import API_ENDPOINTS, { IFetchPasswordMaskRequest } from '../services/TheSafestBankApi/safestBankServerApiEndpoints';
import PartialPasswordForm from '../features/auth/PartialPasswordForm';
import ModalContext from '../features/modal/context/ModalContext';

const LoginPage = () => {
  const [clientNumber, setClientNumber] = useState<string>('');
  const [passwordMask, setPasswordMask] = useState<number[] | null>(null);
  const { isAuthenticated, login } = useContext(AuthContext);
  const { openModal, openSpinner, closeSpinner } = useContext(ModalContext);
  const navigate = useNavigate();

  const handleSubmitClientNumber = async () => {
    try {
      openSpinner();
      validateClientNumber();
      const requestBody: IFetchPasswordMaskRequest = { clientNumber };

      const response = await fetch(API_ENDPOINTS.FETCH_PASSWORD_MASK, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
      });

      const data = await response.json();

      if (!response.ok) {
        throw new Error(data.message);
      }

      setPasswordMask(data);
    } catch (error) {
      handleRequestError((error as Error).message);
    } finally {
      closeSpinner();
    }
  };

  const validateClientNumber = () => {
    if (!clientNumber) {
      throw new Error('Client number is required.');
    }

    if (!/^[0-9]+$/.test(clientNumber)) {
      throw new Error('Client number must be a number.');
    }
  };

  const handleRequestError = (errorMessage: string) => {
    openModal('Error', `Failed to fetch password combination. ${errorMessage}`);
  };


  const handleClientNumberChange = (event: ChangeEvent<HTMLInputElement>) => {
    setClientNumber(event.target.value);
  };

  const handleLogin = (password: string) => {
    login(clientNumber, password);
  };

  const handleForgotPassword = () => {
    navigate('/password-reset');
  }

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
              {passwordMask && (
                <>
                  <h3>Provide the following letters of the password for the client with number: "{clientNumber}"</h3>
                  <PartialPasswordForm
                    mask={passwordMask}
                    onSubmit={handleLogin}
                  />
                </>
              )}
              <button className="secondary-action-button" onClick={handleForgotPassword}>Forgot Password?</button>
            </div>
          )
      }
    </>
  );
}

export default LoginPage;