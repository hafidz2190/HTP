import axios from "axios"

import { baseUrl } from "../constants/config"

const apiClient = axios.create({
    baseURL: baseUrl,
})

export default apiClient