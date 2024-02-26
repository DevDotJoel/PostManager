export interface LoginUserModel {
  email: string;
  password: string;
}
export interface RegisterUserModel {
username:string,
email:string,
password:string,
password2:string
}

export interface AuthUserModel {
  id: string;
  email: string;
  username: string;
}

export interface AuthResultModel{
  token:string,
  user:AuthUserModel

}