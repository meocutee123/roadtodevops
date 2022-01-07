import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { KanjiService } from 'src/app/services/apis/country/kanji.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  isActive: boolean = false

  constructor(private _kanjiService: KanjiService) { }

  ngOnInit(): void {

  }
  isAuthenticated(): boolean {
    return false;
  }
  dragElement(e: HTMLElement) {

    const el = e as HTMLElement;
    const dragableElement = e.querySelector(".dragable") as HTMLElement;

    let startX = 0, startY = 0, startWidth = 0, startHeight = 0;

    const dragMouseDown = (e: MouseEvent) => {
      e = e || window.event;
      e.preventDefault();
      // get the mouse cursor position at startup:
      startWidth = e.clientX;
      startHeight = e.clientY;
      document.onmouseup = closeDragElement;
      // call a function whenever the cursor moves:
      document.onmousemove = elementDrag;
    }

    const elementDrag = (e: MouseEvent) => {
      e = e || window.event;
      e.preventDefault();
      // calculate the new cursor position:
      startX = startWidth - e.clientX;
      startY = startHeight - e.clientY;
      startWidth = e.clientX;
      startHeight = e.clientY;
      // set the el's new position:
      el.style.top = (el.offsetTop - startY) + "px";
      el.style.left = (el.offsetLeft - startX) + "px";
    }

    function closeDragElement() {
      // stop moving when mouse button is released:
      document.onmouseup = null;
      document.onmousemove = null;
    }

    dragableElement ? (dragableElement.onmousedown = dragMouseDown)
      : (el.onmousedown = dragMouseDown)


  }
  getNotification(evt: string) {
    const body = document.querySelector("body") as HTMLElement
    body.style.cursor = "wait"
    setTimeout(() => {
      this.isActive = true
      body.style.cursor = "default"
    }, 500)
    setTimeout(() => {
      this.dragElement(document.querySelector("#mydiv") as HTMLElement)
    }, 1000)
  }
  close() {
    this.isActive = false;
  }
  getCredentials() {
    return JSON.parse(localStorage.getItem("jwt")!)
  }
  getKanjiAsync() {
    this._kanjiService.getKanji().subscribe({
      next: (response) => console.log(response),
      error: (err) => console.log(err)
    })
  }
}
