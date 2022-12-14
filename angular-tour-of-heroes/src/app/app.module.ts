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
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MainPageComponent } from './main-page/main-page.component';
import { AuthGuard } from "./guards/auth.guard";
import { ProfileComponent } from './profile/profile.component';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { authInterceptorProviders } from './helpers/auth.interceptor';


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
    MainPageComponent,
    ProfileComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,

  ],
  providers: [
    AuthGuard,
    authInterceptorProviders,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
