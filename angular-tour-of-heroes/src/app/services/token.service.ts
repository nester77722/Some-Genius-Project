import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import {Tokens} from "../interfaces";
const tokensKey:string = 'tokens';
@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private jwtHelper: JwtHelperService = new JwtHelperService();


  constructor() { }
  saveTokens(tokens:Tokens){
    window.localStorage.removeItem(tokensKey);
    window.localStorage.setItem(tokensKey, JSON.stringify(tokens));
  }
  getTokens():Tokens|null{
    let json = window.localStorage.getItem(tokensKey);
    if (json){
      let result = JSON.parse(json);
      return result;
    }
    return null;
  }
  deleteTokens():void{
    window.localStorage.removeItem(tokensKey);
  }

  isLoggedIn():boolean{
    let json = window.localStorage.getItem(tokensKey);

    if (json){
      let tokens = JSON.parse(json) as Tokens;

      if (tokens){
        if (tokens.accessToken){
          let isExpired = this.jwtHelper.isTokenExpired(tokens.accessToken);
        }
      }


    }

    return false;
  }

}

