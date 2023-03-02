"use client";
import "bootstrap/dist/css/bootstrap.min.css";
import { Inter } from "@next/font/google";
import "./globals.css";
import { Trending } from "@/shared/components/trending";
import SideMenu from "@/shared/components/sidemenu";
import Script from "next/script";
import { FooterNavBar } from "@/shared/components/footer.navbar";
import { ReactNode } from "react";
import { SessionProvider } from "next-auth/react";
import { Navbar } from "@/shared/components/navbar";
import { MainLayout } from "@/shared/components/main.layout";
interface IProps {
  children: ReactNode;
  session: any;
}
const inter = Inter({ subsets: ["latin"] });
export default function RootLayout({ children, session }: IProps) {
  return (
    <html lang="en" className={inter.className}>
      {/*
        <head /> will contain the components returned by the nearest parent
        head.tsx. Find out more at https://beta.nextjs.org/docs/api-reference/file-conventions/head
      */}

      <head />
      <body>
        <Script
          src="https://kit.fontawesome.com/b7eb7b6f40.js"
          crossOrigin="anonymous"
        />
        <SessionProvider session={session}>
          <MainLayout>{children}</MainLayout>
        </SessionProvider>
      </body>
    </html>
  );
}
