import { Component, OnInit } from '@angular/core';
import { Location } from "@angular/common";
import { TokenService } from '../services/token.service';
import { User } from '../interfaces';



@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  isLoggedIn: boolean = false;
  user: User | null = null;
  constructor(private location: Location, private tokenService: TokenService) { }

  ngOnInit() {
    this.tokenService.isLoggedIn().then(result => {
      this.isLoggedIn = result
    });
  }
  logOut() {
    this.tokenService.deleteTokens();
  }
  goBack() : void{
    this.location.back()
  }
}
