import { configureAuth } from "react-query-auth";
import {
  AuthResultModel,
  AuthUserModel,
  LoginUserModel,
} from "../features/auth/types";
import { loginWithEmailAndPassword } from "../features/auth/api/login";
import { getUser } from "../features/auth/api/getUser";
async function logoutFn() {
  localStorage.removeItem("token");
  window.location.reload();
}
async function loginFn(data: LoginUserModel) {
  const response = await loginWithEmailAndPassword(data);
  const user = await handleUserResponse(response);
  return user;
}
async function handleUserResponse(data: AuthResultModel) {
  const { token, user } = data;
  localStorage.setItem("token", token);
  return user;
}
async function registerFn() {
  return Promise.resolve({} as AuthUserModel);
}

async function userFn() {
  if (!localStorage.getItem("token")) return null;
  else {
    const user = await getUser();
    return user ?? null;
  }
}
export const { useUser, useLogin, useLogout } = configureAuth({
  userFn,
  loginFn,
  registerFn,
  logoutFn: () => logoutFn(),
});
