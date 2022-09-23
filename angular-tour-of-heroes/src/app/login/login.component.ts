import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {TokenService} from "../services/token.service";
import {LoginModel} from "../interfaces";
import {Router} from "@angular/router";
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';



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
  constructor(private authService:AuthService, private tokenService:TokenService, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }
  submit(){
    this.messages = [];
    this.authService.login(this.loginModel)
      .subscribe(response => {
        this.tokenService.saveTokens(response);
        this.activeModal.close('Close click');
        window.location.reload();
      },
        err => {
          this.messages.push(err.error.message);
          for (let error of err.error.errors){
            this.messages.push(error);
          }
        })
  }

}
