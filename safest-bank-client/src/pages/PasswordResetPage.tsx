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
    const tokenFromUrl = new URLSearchParams(window.location.search).get('token');
    const parsedToken = tokenFromUrl;

    if (parsedToken === null) return;

    setToken(parsedToken);
    window.history.pushState({}, '', '/password-reset');
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
        throw new Error(`Failed reset password. ${data.message}`);
      }

      openModal('Success', 'Password reset mail sent successfully.');
      navigate('/login')
    } catch (error) {
      openModal('Error', `${(error as Error).message}`);
    }
    finally {
      closeSpinner();
    }
  };

  const handleResetPassword = async () => {
    try {
      openSpinner();
      validatePassword();
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
      openModal('Success', 'Password has been reset successfully.');
      navigate('/login')
    } catch (error) {
      openModal('Error', `${(error as Error).message}`);
    }
    finally {
      closeSpinner();
    }
  };

  const validatePassword = () => {
    if (password !== confirmPassword) {
      throw new Error('Passwords do not match.');
    }

    if (password.length < 16 || password.length > 64) {
      throw new Error('Password must be at least 16 characters long. (Max 64)');
    }

    if (/^(?=.*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*[!@#$%^&*()\-_+. ])[a-zA-Z\d!@#$%^&*()\-_+. ]{16,64}$/.test(password) === false) {
      throw new Error('Password must contain at least two uppercase letter, one lowercase letter, \
                      two numbers and two special signs [!@#$%^&*()\-_+. ]. No special letters are allowed.');
    }

    if (calculateEntropy(password) < 4) {
      throw new Error('Password entropy is too low. Please choose a different password.');
    }
  };

  const calculateEntropy = (password: string) => {
    let chars: { [index: number]: number } = {};
    for (let c of password) {
      let i = c.charCodeAt(0);
      if (chars[i]) {
        chars[i]++;
      }
      else {
        chars[i] = 1;
      }
    }

    let len = password.length;
    let res = 0;
    let tmp = 0;
    for (let i in chars) {
      tmp = chars[i] / len;
      res -= tmp * Math.log2(tmp);
    }
    return res;
  }

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
      {token === '' ? (
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
