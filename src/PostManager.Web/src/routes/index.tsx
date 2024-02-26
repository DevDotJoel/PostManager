import { protectedRoutes } from "./protected";
import { useRoutes } from "react-router-dom";
import { publicRoutes } from "./public";

export const AppRoutes = () => {
  const routes = [...protectedRoutes, ...publicRoutes];
  const element = useRoutes([...routes]);
  return <>{element}</>;
};
