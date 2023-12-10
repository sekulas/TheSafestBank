import { useState, ChangeEvent, useContext } from 'react';
import { Form, Navigate } from 'react-router-dom';
import AuthContext from '../context/AuthContext';

const LoginPage = () => {
  const [clientId, setClientId] = useState<string>('');
  const [passwordCombination, setPasswordCombination] = useState<string>('');
  const [enteredPassword, setEnteredPassword] = useState<string>('');
  const { isAuthenticated, login } = useContext(AuthContext);


  const handleClientIdChange = (event: ChangeEvent<HTMLInputElement>) => {
    setClientId(event.target.value);
  };

  const handleSubmitClientId = () => {
    // Send the Client ID to the server and receive the password combination
    // Simulate server response for demonstration purposes
    const fakeServerResponse = 'abc';
    setPasswordCombination(fakeServerResponse);
  };

  const handlePasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
    setEnteredPassword(event.target.value);
  };

  const handleLogin = () => {
    login();
  };

  return (
    <>
      {
        isAuthenticated ? (
          <Navigate to="/home" />
        )
          : (
            <div id="login-page">
              <h1>Login</h1>
              <input
                type="text"
                placeholder="Client ID"
                value={clientId}
                onChange={handleClientIdChange}
              />
              <button onClick={handleSubmitClientId}>Submit Client ID</button>

              {passwordCombination && (
                <>
                  <h2>Password</h2>
                  <Form method="post">
                    <input
                      type="password"
                      placeholder="Enter password"
                      value={enteredPassword}
                      onChange={handlePasswordChange}
                    />
                    <button onClick={handleLogin}>Login</button>
                  </Form>
                </>
              )}
            </div>
          )
      }
    </>
  );
}

export default LoginPage;