import { Component, OnInit } from '@angular/core';
import {TokenService} from "./services/token.service";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Tour of Heroes';
  isLoggedIn:boolean = false;
  constructor(private tokenService:TokenService) {
  }
ngOnInit(){
  if(this.tokenService.getTokens() == null){
    this.isLoggedIn = false;
  }
  else{
    this.isLoggedIn = true;
  }
}
logOut(){
    this.tokenService.deleteTokens();
  this.isLoggedIn = false;
}

}

