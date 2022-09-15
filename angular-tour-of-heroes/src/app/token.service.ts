import { Injectable } from '@angular/core';
import {Tokens} from "./interfaces";
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
}
