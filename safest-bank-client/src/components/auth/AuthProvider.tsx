import { ReactNode, useState } from 'react';
import AuthContext from '../../context/AuthContext';

const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
  const [clientId, setClientId] = useState<string>("");
  const [name, setName] = useState<string>("");
  const [surname, setSurname] = useState<string>("");

  const login = () => {
    setIsAuthenticated(true);
    setClientId('123');
    setName('John');
    setSurname('Doe');
  }
  const logout = () => {
    setIsAuthenticated(false);
    setClientId('');
    setName('');
    setSurname('');
  }

  return (
    <AuthContext.Provider value={{ isAuthenticated, clientId, name, surname, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export default AuthProvider;