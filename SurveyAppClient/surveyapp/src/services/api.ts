import axios from 'axios';

const baseURL = 'https://localhost:7113/api';

const api = axios.create({
  baseURL,
});

export default api;
