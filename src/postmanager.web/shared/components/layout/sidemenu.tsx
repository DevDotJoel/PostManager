export default function SideMenu({ user }: any) {
  return (
    <>
      <div className="card shadow rounded ">
        <div className="card-body ">
          <h3 className="card-title text-center">
            <b>Menu</b>
          </h3>
          <div className="row">
            <div className="col">Username {user.email}</div>
          </div>
        </div>
      </div>
    </>
  );
}
