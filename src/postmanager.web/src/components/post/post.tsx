"use client";

import { Post } from "@/models/post";
import { useState } from "react";

export default function Post({ data }: any) {
  const [post, setPost] = useState<Post>(data);
  return (
    <>
      <div className="card-body">
        <div className="row mt-3">
          <div className="col">
            <h5>{post.author.username}</h5>
          </div>
        </div>
        <div className="row">
          <div className="col">
            <h6>{post.text}</h6>
          </div>
        </div>
        <div className="row mt-2">
          <div className="col-4 ">
            <div>
              <button className="btn btn-outline-success bg-gradient">
                <i className="fa-solid fa-heart"></i>
              </button>
              <span className="ms-2">{post.totalLikes}</span>
            </div>
          </div>
          <div className="col-4">
            <button className="btn btn-outline-success bg-gradient">
              <i className="fa-solid fa-comment"></i>
            </button>
            <span className="ms-2">{post.totalLikes}</span>
          </div>
          <div className="col-4">
            <button className="btn btn-outline-success bg-gradient">
              <i className="fa-solid fa-share"></i>
            </button>
            <span className="ms-2"> 230 </span>
          </div>
        </div>
      </div>
    </>
  );
}
