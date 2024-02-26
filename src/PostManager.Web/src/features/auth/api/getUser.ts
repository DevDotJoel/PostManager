import { axiosClient } from "../../../libs/axios";
import {  AuthUserModel } from "../types";

export const getUser = (): Promise<AuthUserModel> => {
    return axiosClient.get('/Users/CurrentUser');
  };