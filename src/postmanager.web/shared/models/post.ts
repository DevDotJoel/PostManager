export interface PostModel{
    id: number;
    text:string,
    totalLikes:number,
    totalComments:number,
    author:AuthorModel,
    createdDate:string,

}

export interface AuthorModel{
    username:string;
}