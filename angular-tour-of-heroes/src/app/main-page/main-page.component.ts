import { Component, OnInit } from '@angular/core';
import {Location} from "@angular/common";
import { TokenService } from '../services/token.service';



@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(private location:Location, private tokenService:TokenService) { }

  ngOnInit(){
    this.tokenService.isLoggedIn().then(result => {
      this.isLoggedIn = result
    });
  }
  logOut(){
    this.tokenService.deleteTokens();
  }

}
