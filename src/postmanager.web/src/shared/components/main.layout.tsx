import { getServerSession } from "next-auth";
import { useSession } from "next-auth/react";
import { useEffect, useState } from "react";
import { getCurrentUser, getSession } from "../session";
import { FooterNavBar } from "./footer.navbar";
import { Navbar } from "./navbar";

export function MainLayout({ children }: any) {
  const { data: session, status } = useSession();
  if (status === "loading") {
    return <></>;
  }
  return (
    <>
      <Navbar />
      <main>
        <div className="container-fluid   d-flex flex-column min-vh-100">
          {children}
        </div>
      </main>
      <FooterNavBar />
    </>
  );
}
