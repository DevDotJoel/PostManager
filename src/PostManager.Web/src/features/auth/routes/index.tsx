import { Route, Routes } from "react-router-dom";
import { LoginPage } from "./login.page";

export const AuthRoutes = () => {
  return (
    <Routes>
      <Route path="login" element={<LoginPage />} />
    </Routes>
  );
};
