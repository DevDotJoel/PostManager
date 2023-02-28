import { useSession } from "next-auth/react";
import Link from "next/link";

export function Navbar() {
  const { data: session } = useSession();
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-light bg-light bg-gradient shadow sticky-top ">
        <div className="container">
          <Link className="navbar-brand text-dark" href="/">
            MyPost
          </Link>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          {session?.user && (
            <div
              className="collapse navbar-collapse justify-content-center"
              id="navbarSupportedContent"
            >
              <ul className="navbar-nav mb-2 mb-lg-0">
                <form className="d-flex">
                  <input
                    className="form-control me-2"
                    type="search"
                    placeholder="search user, post"
                    aria-label="Search"
                  />
                  <button className="btn btn-outline-success" type="button">
                    Search
                  </button>
                </form>
              </ul>
            </div>
          )}
        </div>
      </nav>
    </>
  );
}
