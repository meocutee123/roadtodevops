import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router,
    private _jwtHelper: JwtHelperService) { }

  canActivate() {
    return true;
  }
  // couldGetToken() {
  //   const result = this._kanjiService.refreshToken().subscribe(response => console.log(response));
  //   console.log(result)
  //   if(result != null) return true
  //   return false
  // }
}