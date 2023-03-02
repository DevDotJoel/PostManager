import Post from "@/shared/components/post";
import SideMenu from "@/shared/components/sidemenu";
import { Trending } from "@/shared/components/trending";
import { getCurrentUser } from "@/shared/session";
import { getServerSession } from "next-auth";

async function getData() {
  const res = await fetch(
    process.env.NEXT_PUBLIC_API_URL + "api/User/post/JoelFerreira/1",
    {
      cache: "no-store",
    }
  );
  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }
  return res.json();
}
async function getUser() {
  const session = await getCurrentUser();
  return session;
}
export default async function Page() {
  const result = await getData();
  const user = await getUser();
  return (
    <>
      <div className="row">
        <div className="col col-sm-4 d-none d-lg-block ">
          <SideMenu user={user} />
        </div>
        <div className="col ">
          <div className="row">
            <div className="col">
              <div className="card shadow">
                <div className="card-body">
                  <h3 className="card-title text-center">
                    <b>Home</b>
                  </h3>
                </div>
              </div>
            </div>
          </div>
          <div className="row mt-3">
            <div className="col">
              <Post data={result.data} />
            </div>
          </div>
        </div>
        <div className="col d-none d-md-block">
          <Trending />
        </div>
      </div>
    </>
  );
}
