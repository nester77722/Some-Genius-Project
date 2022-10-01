import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { from, map, switchMap, catchError } from 'rxjs';
import { Tokens, User } from '../interfaces';
import { AuthService } from "./auth.service";
const tokensKey: string = 'tokens';
const userIdKey: string = "userId";
@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private jwtHelper: JwtHelperService = new JwtHelperService();
  private isRefreshing: boolean = false;
  private refreshPromise: Promise<void | Tokens | undefined> | null = null;


  constructor(private authService: AuthService) { }
  saveTokens(tokens: Tokens) {
    window.localStorage.removeItem(tokensKey);
    window.localStorage.setItem(tokensKey, JSON.stringify(tokens));

    let userData = this.jwtHelper.decodeToken(tokens.accessToken);
    this.saveUser(userData);
  }
  getTokens(): Tokens | null {
    let json = window.localStorage.getItem(tokensKey);
    if (json) {
      let result = JSON.parse(json);
      return result;
    }
    return null;
  }
  deleteTokens(): void {
    window.localStorage.removeItem(tokensKey);
  }

  async isLoggedIn(): Promise<boolean> {
    let json = window.localStorage.getItem(tokensKey);

    if (json) {
      let tokens = JSON.parse(json) as Tokens;

      if (tokens) {
        if (tokens.accessToken) {
          let isExpired = this.jwtHelper.isTokenExpired(tokens.accessToken);

          if (!isExpired) {
            return true;
          }

          if (!this.isRefreshing) {
            this.isRefreshing = true;

            this.refreshPromise = this.authService.refresh(tokens).toPromise().catch(err => {
              console.log(err);
              this.deleteTokens();
            });

            let newTokens = await this.refreshPromise;
            this.isRefreshing = false;

            if (newTokens) {
              this.saveTokens(newTokens);

              return true;
            }
            else {
              this.deleteTokens();

              return false;
            }
          }

          if (this.isRefreshing) {
            if (this.refreshPromise) {
              return this.refreshPromise.then(response => {
                if (response) {
                  return true;
                }

                return false;
              }).catch(() => {
                return false;
              });
            }
          }

        }
      }


    }

    return false;
  }

  private saveUser(data: any): void {
    window.localStorage.removeItem(userIdKey);
    var userId = data["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    window.localStorage.setItem(userIdKey, JSON.stringify(userId));
  }

  getUserId():string|null{
    let json = window.localStorage.getItem(userIdKey);

    if(json){
      let user = JSON.parse(json);

      return user;
    }

    return null;
  }
}

