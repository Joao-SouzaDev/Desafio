import axios from "axios";
import Cookies from "js-cookie";

const api = axios.create({
  baseURL: "https://localhost:5005/api",
});

export default api;
