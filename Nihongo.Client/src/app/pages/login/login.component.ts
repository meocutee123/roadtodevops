import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '@app/_services';
import { first } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = new FormGroup({});
  isLoading: boolean = false;
  isSubmitted: boolean = false;
  returnUrl: string = "";
  error: string = "";

  constructor(private router: Router, private formBuilder: FormBuilder, private route: ActivatedRoute, private authenticationService: AuthenticationService) {
    if (this.authenticationService.userValue != null) {
      this.router.navigate(["/"])
    }
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", Validators.required]
    })

    this.returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/";
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  login() {
    this.isSubmitted = true;

    if (this.loginForm.invalid) return;

    this.isLoading = true;
    this.authenticationService.login(this.f["username"].value, this.f["password"].value)
      .pipe(first())
      .subscribe({
        next: () => {
          this.router.navigate([this.returnUrl])
        },
        error: error => {
          this.error = error;
          this.isLoading = false;
        }
      })
  }

  cancel() { }
}
