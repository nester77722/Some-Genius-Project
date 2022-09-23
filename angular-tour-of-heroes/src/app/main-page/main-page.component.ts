import { Component, OnInit } from '@angular/core';
import {Location} from "@angular/common";



@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  isLoggedIn:boolean = false;

  private tokenService: any;
  constructor(private location:Location) { }

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
