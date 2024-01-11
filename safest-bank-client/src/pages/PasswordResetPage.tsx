import { useNavigate } from "react-router-dom";
import API_ENDPOINTS, { IResetPasswordRequest, ISendResetMailRequest } from "../services/TheSafestBankApi/safestBankServerApiEndpoints";
import { ChangeEvent, useContext, useEffect, useState } from "react";
import ModalContext from "../features/modal/context/ModalContext";

const PasswordResetPage = () => {
  const [clientNumber, setClientNumber] = useState<string>('');
  const [email, setEmail] = useState<string>('');
  const [token, setToken] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [confirmPassword, setConfirmPassword] = useState<string>('');
  const { openModal, openSpinner, closeSpinner } = useContext(ModalContext);
  const navigate = useNavigate();

  useEffect(() => {
    const urlSearchParams = new URLSearchParams(window.location.search);
    const urlParams = Object.fromEntries(urlSearchParams.entries());
    const parsedToken = urlParams.token;
    console.log(parsedToken)
    setToken(parsedToken);
  }, []);

  const handleSendPasswordResetMail = async () => {
    try {
      openSpinner();
      const requestBody: ISendResetMailRequest = { clientNumber: clientNumber, email: email };

      const response = await fetch(API_ENDPOINTS.RESET_PASSWORD, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
        credentials: 'include',
      });

      if (!response.ok) {
        const data = await response.json();
        throw new Error(`Failed send password reset mail. ${data.message}`);
      }

      openModal('Success', 'Password reset mail sent successfully.');
    } catch (error) {
      openModal('Error', `${(error as Error).message}`);
    }
    finally {
      closeSpinner();
      navigate('/login')
    }
  };

  const handleResetPassword = async () => {
    try {
      openSpinner();
      const requestBody: IResetPasswordRequest = { password: password, confirmPassword: confirmPassword, token: encodeURIComponent(token) };
      console.log(requestBody.token)
      const response = await fetch(API_ENDPOINTS.RESET_PASSWORD, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
        credentials: 'include',
      });

      if (!response.ok) {
        const data = await response.json();
        throw new Error(`Failed reset password. ${data.message}`);
      }
      openModal('Success', 'Password reset mail sent successfully.');
    } catch (error) {
      openModal('Error', `${(error as Error).message}`);
    }
    finally {
      closeSpinner();
      navigate('/login')
    }
  };

  const handleClientNumberChange = (event: ChangeEvent<HTMLInputElement>) => {
    setClientNumber(event.target.value);
  }

  const handleEmailChange = (event: ChangeEvent<HTMLInputElement>) => {
    setEmail(event.target.value);
  }

  const handlePasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  }

  const handleConfirmPasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
    setConfirmPassword(event.target.value);
  }

  return (
    <div id="password-reset-page">
      {token === undefined ? (
        <>
          <h1>Change Password</h1>
          <h3>Provide the client number:</h3>
          <input type="text" placeholder="Client number" onChange={handleClientNumberChange} />
          <br />
          <h3>Provide client email:</h3>
          <input type="text" placeholder="Client email" onChange={handleEmailChange} />
          <br />
          <button
            className="main-action-button"
            onClick={handleSendPasswordResetMail}
          >
            Send password reset mail
          </button>
        </>
      ) : (
        <>
          <h1>Provide new password</h1>
          <h3>Provide new password:</h3>
          <input type="password" placeholder="New password" onChange={handlePasswordChange} />
          <br />
          <h3>Confirm new password:</h3>
          <input type="password" placeholder="Confirm new password" onChange={handleConfirmPasswordChange} />
          <br />
          <button className="main-action-button" onClick={handleResetPassword}>
            Change password
          </button>
        </>
      )}
    </div>
  );
};

export default PasswordResetPage;
