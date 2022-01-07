import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {

  @Output() notifyParent: EventEmitter<any> = new EventEmitter();

  isDisabled : boolean = false

  credentials: any  = {
    username: "",
    password: ""
  }

  constructor() { }



  ngOnInit(): void {
  }

  login() {
    this.isDisabled = true
    this.notifyParent.emit(this.credentials)
  }
  cancel() {
    for (let menber in this.credentials)
      this.credentials[menber] = ""
  }
}
