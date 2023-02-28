export interface Post{
    id: number;
    text:string,
    totalLikes:number,
    totalComments:number,
    author:Author,
    createdDate:string,

}

export interface Author{
    username:string;
}