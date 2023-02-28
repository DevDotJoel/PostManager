"use client";

import { signIn } from "next-auth/react";
import Link from "next/link";
import { useState } from "react";

export default function LoginForm() {
  const [user, setUser] = useState({ email: "", password: "" });

  function onChange({ target }: any) {
    const updatedUser = { ...user, [target.name]: target.value };
    setUser(updatedUser);
  }

  async function submit(e: any) {
    e.preventDefault();
    const result = await signIn("credentials", {
      email: user.email,
      password: user.password,
      redirect: true,
      callbackUrl: "/",
    });
  }

  return (
    <>
      <div className="row d-flex justify-content-center">
        <div className="col col-sm-10 col-md-8 col-lg-6 col-xl-4">
          <div className="card shadow w-100">
            <div className="card-body">
              <div className="row mt-3 d-flex justify-content-center">
                <div className="col col-sm-8">
                  <h3 className="card-title">
                    {" "}
                    <b> Login</b>
                  </h3>
                </div>
              </div>
              <form onSubmit={submit} className="was-validated">
                <div className="row mt-4 d-flex justify-content-center">
                  <div className="col col-sm-8">
                    <label htmlFor="email" className="form-label">
                      Email
                    </label>
                    <input
                      type="email"
                      className="form-control"
                      id="email"
                      name="email"
                      onChange={onChange}
                      value={user.email}
                      required
                    />
                    <div className="invalid-feedback">email is required</div>
                  </div>
                </div>
                <div className="row mt-4 d-flex justify-content-center">
                  <div className="col col-sm-8">
                    <label htmlFor="password" className="form-label">
                      Password
                    </label>
                    <input
                      type="password"
                      className="form-control"
                      id="password"
                      name="password"
                      onChange={onChange}
                      value={user.password}
                      required
                    />
                    <div className="invalid-feedback">password is required</div>
                  </div>
                </div>
                <div className="row mt-4 d-flex justify-content-center">
                  <div className="col col-sm-8">
                    <div>
                      <button
                        type="submit"
                        className="btn btn-success w-100 shadow"
                      >
                        Login
                      </button>
                    </div>
                  </div>
                </div>
                <div className="row mt-2 d-flex justify-content-center">
                  <div className="col col-sm-8 d-flex justify-content-end">
                    <Link href={"/auth/forgot-password"} className="text-muted">
                      Forgot Password?
                    </Link>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
