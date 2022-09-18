import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Config} from "../Config";
import {Observable} from "rxjs";
import {Game} from "../interfaces";

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private apiUrl = Config.apiUrl;
  private gameUrl = 'api/game'
  constructor(private httpClient:HttpClient) { }
  getGames():Observable<Game[]>{
    const url = this.apiUrl + '/' + this.gameUrl;
    return this.httpClient.get<Game[]>(url);
  }
  getGame(id:string):Observable<Game>{
    const url = this.apiUrl + '/' + this.gameUrl + '/' + id;
    return this.httpClient.get<Game>(url);
  }
}
