import axios from "axios";
import Cookies from "js-cookie";

const api = axios.create({
  baseURL: "https://localhost:5003/api",
});

api.interceptors.request.use(config => {
  const token = Cookies.get("token");
  if (token) {
    config.headers.Accept = `Bearer ${token}`;
  }
  return config;
});

export default api;
