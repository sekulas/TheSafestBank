import { createContext } from 'react';

export interface IAuthContext {
  isAuthenticated: boolean;
  clientId: string;
  name: string;
  surname: string;
  login: (clientNumber: string, password: string) => void;
  logout: () => void;
  setClientData: (data: IBankClient | null) => void;
}

export interface IBankClient {
  clientId: string;
  name: string;
  surname: string;
}

const AuthContext = createContext<IAuthContext>({ isAuthenticated: false, clientId: "", name: "", surname: "", login: () => { }, logout: () => { }, setClientData: () => { } } as IAuthContext);

export default AuthContext;