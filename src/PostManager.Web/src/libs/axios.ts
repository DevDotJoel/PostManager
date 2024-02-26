
import axios from "axios";
import { API_URL } from "../config";
import { toast } from "react-toastify";

  export const axiosClient = axios.create({
    baseURL: API_URL,
  });

  axiosClient.interceptors.request.use(
    (config: any) => {
      const token = localStorage.getItem("token");
      if (token) {
        config.headers["Authorization"] = "Bearer " + token;
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
  axiosClient.interceptors.response.use(
    (response) => {
      return response.data;
    },
    (error) => {
      const message = error.response?.data?.error?error.response?.data?.error: error.response?.data?.title;;
      toast.error(message)
      // useNotificationStore.getState().addNotification({
      //   type: 'error',
      //   title: 'Error',
      //   message,
      // });
  
      return Promise.reject(error);
    }
  );