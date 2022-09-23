import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {TokenService} from "./services/token.service";
import { LoginComponent } from './login/login.component';
import {RegisterComponent} from "./register/register.component";



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Tour of Heroes';
  isLoggedIn: boolean = false;
  constructor(private tokenService:TokenService, private modalService: NgbModal) {
  }
ngOnInit(){
  this.tokenService.isLoggedIn().then(result => {
    this.isLoggedIn = result
  });
}
logOut(){
    this.tokenService.deleteTokens();
    window.location.reload();
}

openLoginModal(){
  this.modalService.open(LoginComponent);
}

openRegisterModal(){
  this.modalService.open(RegisterComponent)
}


}

