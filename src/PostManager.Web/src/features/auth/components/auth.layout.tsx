export const AuthLayout = ({ children }: any) => {
  return (
    <>
      <div className="container-fluid d-flex flex-column">
        <div>{children}</div>
      </div>
    </>
  );
};
