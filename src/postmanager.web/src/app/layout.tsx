import "bootstrap/dist/css/bootstrap.min.css";
import { Inter } from "@next/font/google";
import "./globals.css";
import { Navbar } from "@/shared/navbar";
import { Trending } from "@/shared/components/trending";
import SideMenu from "@/shared/components/sidemenu";
import Script from "next/script";
import { FooterNavBar } from "@/shared/components/footer.navbar";

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
      <body className=" ">
        <Script
          src="https://kit.fontawesome.com/b7eb7b6f40.js"
          crossOrigin="anonymous"
          strategy="beforeInteractive"
        />
        <Navbar />
        <main>
          <div className="container-fluid  d-flex flex-column vh-100">
            <div className="row  ">
              <div className="col col-sm-4 d-none d-lg-block ">
                <SideMenu />
              </div>
              <div className="col">{children}</div>
            </div>
          </div>
        </main>

        <FooterNavBar />
      </body>
    </html>
  );
}
