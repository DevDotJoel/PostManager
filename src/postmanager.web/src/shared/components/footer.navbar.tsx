import Link from "next/link";

export function FooterNavBar() {
  return (
    <>
      <footer className="footer mt-auto py-3 bg-white fixed-bottom shadow d-sm-none">
        <div className="container-fluid">
          <div className="row">
            <div className="col">
              <Link href={"/"} className="btn btn-default  ">
                <i className="fa-solid fa-house"></i>
              </Link>
            </div>
            <div className="col">
              <Link href={"/search"} className="btn btn-default  ">
                <i className="fa-solid fa-magnifying-glass"></i>
              </Link>
            </div>
            <div className="col">
              <Link href={"/message"} className="btn btn-default  ">
                <i className="fa-solid fa-message"></i>
              </Link>
            </div>
            <div className="col">
              <Link href={"/profile"} className="btn btn-default  ">
                <i className="fa-solid fa-user"></i>
              </Link>
            </div>
          </div>
        </div>
      </footer>
    </>
  );
}
