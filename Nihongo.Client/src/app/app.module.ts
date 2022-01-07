import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {JwtModule} from "@auth0/angular-jwt"
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeroesComponent } from './heroes/heroes.component';
import { FormsModule } from '@angular/forms';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from "@angular/common/http" 
import { AuthGuard } from './guards/auth-guard.service';
import { HeroFormComponent } from './common/hero-form/hero-form.component';
import { HomeComponent } from './pages/home/home.component';
import { DesktopIconComponent } from './common/desktop-icon/desktop-icon.component';
import { StartbarComponent } from './common/startbar/startbar.component';
import { ModalComponent } from './common/modal/modal.component';
import { LoginComponent } from './pages/login/login.component';

export function tokenGetter(){
  const jwt = JSON.parse(localStorage.getItem("jwt")!)
  if(jwt != null) return jwt.token
  return null
}

@NgModule({
  declarations: [
    AppComponent,
    HeroesComponent,
    HeroDetailComponent,
    MessagesComponent,
    DashboardComponent,
    HeroFormComponent,
    HomeComponent,
    DesktopIconComponent,
    StartbarComponent,
    ModalComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44366"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
