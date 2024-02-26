import React, { Suspense } from "react";
import { Navigate, Outlet } from "react-router-dom";

import { lazyImport } from "../utils/lazyImport";
import MainLayout from "../components/layout/main-layout";
import { useUser } from "../libs/auth";
import { RoutesPermissions } from "./permissions";

const { EmployeeRoutes } = lazyImport(
  () => import("../features/employees"),
  "EmployeeRoutes"
);
export const App = () => {
  const auth = useUser();
  if (auth.isLoading) return <></>;
  if (auth.isError || !auth.data) return <Navigate to="/auth/login" />;
  return (
    <>
      <MainLayout>
        <Suspense fallback={<></>}>
          <Outlet />
        </Suspense>
      </MainLayout>
    </>
  );
};
export const protectedRoutes = [
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "/employees/*",
        element: (
          <RoutesPermissions permission={"Employee.Read"}>
            <EmployeeRoutes />
          </RoutesPermissions>
        ),
      }
      { path: "*", element: <Navigate to="." /> },
    ],
  },
];
