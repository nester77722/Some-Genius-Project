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

  constructor(public tokenService:TokenService, private modalService: NgbModal) {
  }
ngOnInit(){
}
logOut(){
    this.tokenService.deleteTokens();
}

openLoginModal(){
  this.modalService.open(LoginComponent);
}

openRegisterModal(){
  this.modalService.open(RegisterComponent)
}


}

