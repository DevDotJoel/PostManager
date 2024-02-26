import { Navigate } from "react-router-dom";
import { useUser } from "../libs/auth";

export const RoutesPermissions = ({ children }: any) => {
  const user = useUser({ staleTime: Infinity, gcTime: Infinity });

  if (!user.data) {
    return <Navigate replace to="/" />;
  }

  return children;
};
