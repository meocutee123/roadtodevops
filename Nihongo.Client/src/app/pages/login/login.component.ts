import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ModalComponent } from 'src/app/common/modal/modal.component';
import { KanjiService } from 'src/app/services/apis/country/kanji.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @ViewChild(ModalComponent)
  child!: ModalComponent;

  constructor(private _kanjiService: KanjiService,
    private router: Router) { }

  ngOnInit(): void {
  }

  handleLogin(credentials: any) {
    this._kanjiService.login(credentials).subscribe({
      next: response => {
        if(!response.success) {
          console.log(response)
          return
        }
        this.child.isDisabled = false;
        localStorage.setItem("jwt", JSON.stringify(response))
        this.router.navigate(["/home"])
      },
      error: (error) => {
        console.log(error)
        this.child.isDisabled = false;
      }
    })
  }
}
