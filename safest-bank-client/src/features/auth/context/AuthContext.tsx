import { createContext } from "react";

export interface IAuthContext {
  isAuthenticated: boolean;
  clientNumber: string;
  accountNumber: string;
  balance: number;
  name: string;
  surname: string;
  email: string;
  address: IAddress;
  identityCard: IIdentityCard;
  transactions: ITransaction[];
  login: (clientNumber: string, password: string) => void;
  logout: () => void;
  setClientData: (data: IBankClient | null) => void;
  setTransactions: (transactions: ITransaction[]) => void;
  setBalance: (balance: number) => void;
}

export interface IBankClient {
  clientNumber: string;
  accountNumber: string;
  balance: number;
  name: string;
  surname: string;
  email: string;
  address: IAddress;
  identityCard: IIdentityCard;
  transactions: ITransaction[];
}

export interface IAddress {
  country: string;
  city: string;
  street: string;
  houseNumber: string;
  zipCode: string;
}

export interface IIdentityCard {
  type: string;
  serie: string;
  number: string;
  countryOfIssue: string;
}

export interface ITransaction {
  senderName: string;
  senderSurname: string;
  senderAccountNumber: string;
  recipientName: string;
  recipientSurname: string;
  recipientAccountNumber: string;
  amount: number;
  time: string;
  title: string;
}

const AuthContext = createContext<IAuthContext>({
  isAuthenticated: false,
  clientNumber: "",
  accountNumber: "",
  balance: 0,
  name: "",
  surname: "",
  email: "",
  address: { country: "", city: "", street: "", houseNumber: "", zipCode: "" },
  identityCard: { type: "", serie: "", number: "", countryOfIssue: "" },
  transactions: [],
  login: () => { },
  logout: () => { },
  setClientData: () => { },
  setTransactions: () => { },
  setBalance: () => { },
} as IAuthContext);

export default AuthContext;
