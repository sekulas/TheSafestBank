const API_BASE_URL = "http://localhost:5000/api";

const API_ENDPOINTS = {
  FETCH_PASSWORD_MASK: `${API_BASE_URL}/auth/password`,
  LOGIN: `${API_BASE_URL}/auth/login`,
  LOGOUT: `${API_BASE_URL}/auth/logout`,
  GET_CLIENT: `${API_BASE_URL}/client`,
  MAKE_TRANSACTION: `${API_BASE_URL}/transaction`,
  RESET_PASSWORD: `${API_BASE_URL}/password-reset`,
};

export default API_ENDPOINTS;

export interface IFetchPasswordMaskRequest {
  clientNumber: string;
};

export interface ILoginRequest {
  clientNumber: string;
  password: string;
};

export interface IMakeTransactionRequest {
  recipientAccountNumber: string;
  amount: number;
  title: string;
};

export interface ISendResetMailRequest {
  clientNumber: string;
  email: string;
};

export interface IResetPasswordRequest {
  password: string;
  confirmPassword: string;
  token: string;
};