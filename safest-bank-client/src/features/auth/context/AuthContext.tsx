import { createContext } from 'react';

export interface IAuthContext {
  isAuthenticated: boolean;
  clientId: string;
  name: string;
  surname: string;
  login: (clientNumber: string, password: string) => void;
  logout: () => void;
}

const AuthContext = createContext<IAuthContext>({ isAuthenticated: false, clientId: "", name: "", surname: "", login: () => { }, logout: () => { } } as IAuthContext);

export default AuthContext;