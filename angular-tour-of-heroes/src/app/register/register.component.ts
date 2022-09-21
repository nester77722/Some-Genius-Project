import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {error} from "@angular/compiler-cli/src/transformers/util";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 email:string = '';
 userName:string = '';
 password:string = '';
 messages:string[] = [];
  constructor(private authService:AuthService, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }
  submit() {
    this.messages = [];
    this.authService.register(this.email, this.userName, this.password).subscribe(
      response => {
        this.messages.push(response.message)
        window.location.reload()
      },
      err => {
        this.messages.push(err.error.message);
        for (let error of err.error.errors){
          this.messages.push(error);
        }

      }
    );
  }


}
