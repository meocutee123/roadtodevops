import { Component, OnInit } from '@angular/core';
import { Hero } from "../interfaces/hero";
import { KanjiService } from '../services/apis/country/kanji.service';
import { HeroService } from '../services/hero/hero.service';
import { MessageService } from '../services/message/message.service';
@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.scss']
})

export class HeroesComponent implements OnInit {

  heroes: Hero[] = []

  constructor(private _heroService: HeroService,
    private _messageService: MessageService,
    private _kanjiService: KanjiService) { }

  ngOnInit(): void {
    this.getHeroes()
  }

  getHeroes(): void {
    this._heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes)
  }

}
