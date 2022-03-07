import axios from 'axios';

const api = axios.create({
    baseURL : "https://localhost:7132",
})

export default api;