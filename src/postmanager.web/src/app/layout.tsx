import "bootstrap/dist/css/bootstrap.min.css";
import { Inter } from "@next/font/google";
import "./globals.css";
import { Navbar } from "@/shared/navbar";
import { Trending } from "@/shared/components/trending";
import SideMenu from "@/shared/components/sidemenu";

const inter = Inter({ subsets: ["latin"] });
export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en" className={inter.className}>
      {/*
        <head /> will contain the components returned by the nearest parent
        head.tsx. Find out more at https://beta.nextjs.org/docs/api-reference/file-conventions/head
      */}
      <head />
      <body>
        <Navbar />
        <div className="container-fluid mt-5">
          <div className="row">
            <div className="col col-sm-4">
              <SideMenu />
            </div>
            <div className="col">{children}</div>
          </div>
        </div>
      </body>
    </html>
  );
}
