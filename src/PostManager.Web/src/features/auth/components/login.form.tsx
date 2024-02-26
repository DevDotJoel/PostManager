import React from "react";
import { useNavigate } from "react-router-dom";
import { LoginUserModel } from "../types";
import { useForm } from "react-hook-form";

import { useLogin } from "../../../libs/auth";

export const LoginForm = () => {
  const login = useLogin();
  const navigate = useNavigate();

  const form = useForm<LoginUserModel>({
    defaultValues: {
      email: "",
      password: "",
    },
  });
  async function submit(data: LoginUserModel) {
    await login.mutateAsync(data);
    navigate("/");
  }
  return (
    <>
      <></>
    </>
  );
};
