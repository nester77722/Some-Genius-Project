import { Component, OnInit } from '@angular/core';
import {Location} from "@angular/common";
import { TokenService } from '../services/token.service';



@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(private location:Location, public tokenService:TokenService) { }

  ngOnInit(){
  }
  logOut(){
    this.tokenService.deleteTokens();
  }

}
