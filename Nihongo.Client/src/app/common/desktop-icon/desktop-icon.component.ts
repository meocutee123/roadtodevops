import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-desktop-icon',
  templateUrl: './desktop-icon.component.html',
  styleUrls: ['./desktop-icon.component.scss']
})
export class DesktopIconComponent implements OnInit {

  @Output() notifyParent: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }
   onSingleClick(e : Event) {
     const el = e.target as HTMLElement
     if(el.parentElement?.classList.contains("desktop-icon")){
       el.parentElement?.classList.add("icon-focus");
       return
     }
   }
   onDoubleClick(e : Event) {
    const el = e.target as HTMLElement
    const parentElement = el.parentElement
    if(parentElement?.classList.contains("desktop-icon")){
      parentElement.classList.remove("icon-focus")
      this.sendNotification();
    }
   }

   sendNotification() {
    this.notifyParent.emit('Some value to send to the parent');
}
}
