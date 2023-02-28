import Posts from "@/shared/components/posts";
import { Trending } from "@/shared/components/trending";
import Link from "next/link";

async function getData() {
  const res = await fetch("https://localhost:7165/api/user/JoelFerreira/1", {
    cache: "no-store",
  });
  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }
  return res.json();
}
export default async function HomePage() {
  const result = await getData();
  console.log(result.data);
  return (
    <>
      <div>hehe</div>
    </>
  );
}
