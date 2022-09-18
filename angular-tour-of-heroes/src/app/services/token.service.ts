import { Injectable } from '@angular/core';
import {Tokens} from "../interfaces";
const tokensKey:string = 'tokens';
@Injectable({
  providedIn: 'root'
})
export class TokenService {

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
}
