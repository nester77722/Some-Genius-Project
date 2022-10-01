import {Injectable} from "@angular/core";
import {CanActivate, Router} from "@angular/router";
import {TokenService} from "../services/token.service";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private tokenService: TokenService, private router:Router) {
  }
   canActivate() {
    return  this.tokenService.isLoggedIn().then(result => {
       if(result){
         return true;
       }else {
         this.router.navigate(['home'])
         return false;
       }
     });

  }

}
