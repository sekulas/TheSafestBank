import { createContext } from 'react';

interface IAuthContext {
  isAuthenticated: boolean;
  clientId: string;
  name: string;
  surname: string;
  login: () => void;
  logout: () => void;
}

const AuthContext = createContext<IAuthContext>({ isAuthenticated: false, clientId: "", name: "", surname: "", login: () => { }, logout: () => { } } as IAuthContext);

export default AuthContext;