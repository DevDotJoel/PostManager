import React from "react";
import { LoginForm } from "../components/login.form";
import { useNavigate } from "react-router-dom";
import { useLogin } from "../../../libs/auth";
import { LoginUserModel } from "../types";
import { AuthLayout } from "../components/auth.layout";

export const LoginPage = () => {
  return (
    <>
      <AuthLayout>
        <LoginForm />
      </AuthLayout>
    </>
  );
};
