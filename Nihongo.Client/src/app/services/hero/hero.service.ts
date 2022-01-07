import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { MessageService } from '../message/message.service';
import { HEROES } from 'src/app/db/mock-heroes';
import { Hero } from 'src/app/interfaces/hero';
@Injectable({
  providedIn: 'root'
})
export class HeroService {

  constructor(private _messageService : MessageService) { }

  getHeroes() : Observable<Hero[]> {
    const heroes = of(HEROES)
    this._messageService.add("HERO SERVICE: Fetch heroes")
    return heroes
  }

  getHero(id: number): Observable<Hero> {
    // For now, assume that a hero with the specified `id` always exists.
    // Error handling will be added in the next step of the tutorial.
    const hero = HEROES.find(h => h.id === id)!;
    this._messageService.add(`HeroService: fetched hero id=${id}`);
    return of(hero);
  }

}
