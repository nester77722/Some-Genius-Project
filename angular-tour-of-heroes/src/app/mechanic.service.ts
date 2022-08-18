import { Injectable } from '@angular/core';
import {Config} from "./Config";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Genre, Mechanic} from "./interfaces";

@Injectable({
  providedIn: 'root'
})
export class MechanicService {
  private apiUrl = Config.apiUrl;
  private mechanicUrl = 'api/mechanic'
  private httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private httpClient:HttpClient) { }
  getMechanics():Observable<Mechanic[]>{
    const url = this.apiUrl + '/' + this.mechanicUrl;
    return this.httpClient.get<Mechanic[]>(url);
  }
  getMechanic(id:string):Observable<Mechanic>{
    const url = this.apiUrl + '/' + this.mechanicUrl + '/' + id;
    return this.httpClient.get<Mechanic>(url);
  }
}
