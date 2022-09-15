import { Component, OnInit } from '@angular/core';
import {AuthService} from "../auth.service";
import {TokenService} from "../token.service";
import {LoginModel} from "../interfaces";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
loginModel:LoginModel = {
  username: '',
  password: '',
}
messages:string[] = [];
  constructor(private authService:AuthService, private tokenService:TokenService) { }

  ngOnInit(): void {
  }
  submit(){
    this.messages = [];
    this.authService.login(this.loginModel)
      .subscribe(response => {
        this.tokenService.saveTokens(response);
      },
        err => {
          this.messages.push(err.error.message);
          for (let error of err.error.errors){
            this.messages.push(error);
          }
        })
  }
}
