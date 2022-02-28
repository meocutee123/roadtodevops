import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {

  @Output() notifyParent: EventEmitter<any> = new EventEmitter();

  isDisabled: boolean = false

  credentials: any = {
    username: "",
    password: ""
  }

  constructor() { }

  ngOnInit(): void { }

  login() { }
  cancel() { }
}
