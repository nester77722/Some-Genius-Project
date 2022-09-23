import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import {Tokens} from "../interfaces";
import {AuthService} from "./auth.service";
const tokensKey:string = 'tokens';
@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private jwtHelper: JwtHelperService = new JwtHelperService();
  private isRefreshing:boolean = false;

  constructor(private authService: AuthService) { }
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

          if(!isExpired){
            return true;
          }
          if(this.isRefreshing){
            return true;
          }

            this.isRefreshing = true;
            let refreshSuccessful = false
            this.authService.refresh(tokens).subscribe(response => {
              this.saveTokens(response);
              refreshSuccessful = true;
            },error => {
              this.deleteTokens()
              refreshSuccessful = false;
            })
          this.isRefreshing = false;
            if(refreshSuccessful){
              return true;
            }



        }
      }


    }

    return false;
  }

}

