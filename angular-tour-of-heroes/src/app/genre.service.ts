import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Config} from "./Config";
import {Observable} from "rxjs";
import {Genre} from "./interfaces";

@Injectable({
  providedIn: 'root'
})
export class GenreService {
 private apiUrl = Config.apiUrl;
 private genreUrl = 'api/genre'
  private httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private httpClient:HttpClient) { }
  getGenres():Observable<Genre[]>{
   const url = this.apiUrl + '/' + this.genreUrl;
   return this.httpClient.get<Genre[]>(url);
  }
  getGenre(id:string):Observable<Genre>{
    const url = this.apiUrl + '/' + this.genreUrl + '/' + id;
    return this.httpClient.get<Genre>(url);
  }
}

