import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { GenresComponent } from './genres/genres.component';
import { GenresDetailComponent } from './genres-detail/genres-detail.component';
import { MechanicsComponent } from './mechanics/mechanics.component';
import { RegisterComponent } from './register/register.component';
import { MechanicDetailComponent } from './mechanic-detail/mechanic-detail.component';
import { LoginComponent } from './login/login.component';
import { OtherPageComponent } from './other-page/other-page.component';
import { GamesComponent } from './games/games.component';
import { GameDateilsComponent } from './game-dateils/game-dateils.component';



@NgModule({
  declarations: [
    AppComponent,
    GenresComponent,
    GenresDetailComponent,
    MechanicsComponent,
    RegisterComponent,
    MechanicDetailComponent,
    LoginComponent,
    OtherPageComponent,
    GamesComponent,
    GameDateilsComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
