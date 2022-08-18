import { Component, OnInit } from '@angular/core';
import {AuthService} from "../auth.service";
import {error} from "@angular/compiler-cli/src/transformers/util";

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
  constructor(private authService:AuthService) { }

  ngOnInit(): void {
  }
  submit() {
    this.messages = [];
    this.authService.register(this.email, this.userName, this.password).subscribe(
      response => {
        this.messages.push(response.message)
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
