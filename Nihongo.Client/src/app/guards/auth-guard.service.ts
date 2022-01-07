import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router,
    private _jwtHelper: JwtHelperService) { }

  canActivate() {
    const jwt = JSON.parse(localStorage.getItem("jwt")!)
    if (jwt != null && !this._jwtHelper.isTokenExpired(jwt.token))
      return true
    else {
      this.router.navigate(["/login"])
      return false
    }
  }
}