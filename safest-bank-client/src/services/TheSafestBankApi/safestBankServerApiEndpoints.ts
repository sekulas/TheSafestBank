const API_BASE_URL = "https://localhost:5000/api";

const API_ENDPOINTS = {
  FETCH_PASSWORD_MASK: `${API_BASE_URL}/auth/password`,
  LOGIN: `${API_BASE_URL}/auth/login`,
  LOGOUT: `${API_BASE_URL}/auth/logout`,
  GET_CLIENT: `${API_BASE_URL}/client`,
};

export default API_ENDPOINTS;

export interface IFetchPasswordMaskRequest {
  clientNumber: string;
};

export interface ILoginRequest {
  clientNumber: string;
  password: string;
};