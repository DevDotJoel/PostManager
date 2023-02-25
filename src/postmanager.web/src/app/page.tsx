import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "./page.module.css";

const inter = Inter({ subsets: ["latin"] });

export default function Home() {
  return (
    <>
      <div className="row">
        <div className="col col-sm-4 d-none d-sm-block  ">
          <div className="card shadow rounded ">
            <div className="card-body ">
              <h3 className="card-title text-center">
                <b>Profile</b>
              </h3>
            </div>
          </div>
        </div>
        <div className="col col-sm-4">
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
          <div className="row mt-5">
            <div className="col">
              <div className="card shadow">
                <div className="card-body">
                  <div className="row mt-3">
                    <div className="col">
                      <h5>joelFerreira</h5>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col">
                      <h6>
                        bro o meu dia no trabalho foi uma bela bosta , a cliente
                        com quem falei queria só falar com o manager só pq disse
                        que não havia em stock &#128512;
                      </h6>
                    </div>
                  </div>
                  <div className="row mt-5">
                    <div className="col-4 ">
                      <div>
                        <button className="btn btn-outline-success bg-gradient">
                          <i className="fa-solid fa-heart"></i>
                          {""}
                        </button>
                        <span className="ms-2"> 15</span>
                      </div>
                    </div>
                    <div className="col-4">
                      <button className="btn btn-outline-success bg-gradient">
                        <i className="fa-solid fa-comment"></i>
                      </button>
                      <span className="ms-2"> 230</span>
                    </div>
                    <div className="col-4">
                      <button className="btn btn-outline-success bg-gradient">
                        <i className="fa-solid fa-share"></i>
                      </button>
                      <span className="ms-2"> 230 </span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div className="row mt-5">
            <div className="col">
              <div className="card shadow">
                <div className="card-body">
                  <div className="row mt-3">
                    <div className="col">
                      <h5>joelFerreira</h5>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col">
                      <h6>
                        bro o meu dia no trabalho foi uma bela bosta , a cliente
                        com quem falei queria só falar com o manager só pq disse
                        que não havia em stock &#128512;
                      </h6>
                    </div>
                  </div>
                  <div className="row mt-5">
                    <div className="col">
                      <button className="btn btn-success bg-gradient">
                        Comentários
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col col-sm-4 d-none d-sm-block">
          <div className="card shadow">
            <div className="card-body">
              <h3 className="card-title text-center">
                <b>Trending</b>
              </h3>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
