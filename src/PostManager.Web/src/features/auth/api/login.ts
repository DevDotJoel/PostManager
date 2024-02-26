import { toast } from "react-toastify";
import { axiosClient } from "../../../libs/axios";
import { AuthResultModel, LoginUserModel } from "../types";

export const loginWithEmailAndPassword = (data: LoginUserModel): Promise<AuthResultModel> => {

    return toast.promise(axiosClient.post('/Authentication/Login', data), {
      pending: "Sign in",
      success: "Signed  with success",      
    });
  };