import { Injectable } from '@angular/core';
import {Config} from "./Config";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Genre} from "./interfaces";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = Config.apiUrl;
  private authUrl = 'api/auth'
  private httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private httpClient:HttpClient) { }
  register(email:string, userName:string, password:string):Observable<any>{
    const url = this.apiUrl + '/' + this.authUrl + '/register';
    return this.httpClient.post<any>(url, {
      email:email,
      username:userName,
      password:password,
    },this.httpOptionsJson);
  }

}
