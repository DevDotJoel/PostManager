"use client";

import { Trending } from "./trending";

export default function Posts() {
  return (
    <>
      <div className="row">
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
              <div
                // href={"/user/1/post/hehe"}
                className="card shadow card-hover"
              >
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
                  <div className="row mt-2">
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

          <div className="row mt-3 ">
            <div className="col">
              <div className="card shadow card-hover">
                <div className="card-body">
                  <div className="row mt-3">
                    <div className="col">
                      <h5>SaraSilva</h5>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col">
                      <h6>
                        Estou em formação do tralho em ingles e a stora disse :
                        only when the instructions are... Direitinhas.. Can they
                        be accepted &#129315;
                      </h6>
                    </div>
                  </div>
                  <div className="row mt-2">
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
          <div className="row mt-3 ">
            <div className="col">
              <div className="card shadow card-hover">
                <div className="card-body">
                  <div className="row mt-3">
                    <div className="col">
                      <h5>HelenaVaz</h5>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col">
                      <h6>Casa de BANHO FEITAA HUHUHU &#129315;</h6>
                    </div>
                  </div>
                  <div className="row mt-2">
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
        </div>
        <div className="col d-none d-md-block">
          <Trending />
        </div>
      </div>
    </>
  );
}
