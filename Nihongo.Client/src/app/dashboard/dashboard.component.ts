import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Hero } from '../interfaces/hero';
import { KanjiService } from '../services/apis/country/kanji.service';
import { HeroService } from '../services/hero/hero.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  heroes: Hero[] = [];

  constructor(private _heroService: HeroService,
    private _kanjiService: KanjiService,
    private _jwtHelperService : JwtHelperService) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this._heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes);
  }

  getKanji() : void {
    this._kanjiService.getKanji().subscribe(response => console.log(response))
  }

  login(): void {
   
  }
  logout(): void {
    localStorage.removeItem("token")
    
  }
  isAuthenticated() : boolean {
    const token = localStorage.getItem("token")
    if(token && !this._jwtHelperService.isTokenExpired(token))
      return true
    return false
  }
}
