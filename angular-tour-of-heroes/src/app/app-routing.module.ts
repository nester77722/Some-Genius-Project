import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GenresComponent} from "./genres/genres.component";
import {GenresDetailComponent} from "./genres-detail/genres-detail.component";
import {MechanicsComponent} from "./mechanics/mechanics.component";
import {RegisterComponent} from "./register/register.component";
import {MechanicDetailComponent} from "./mechanic-detail/mechanic-detail.component";
import {LoginComponent} from "./login/login.component";
import {OtherPageComponent} from "./other-page/other-page.component";
import {GamesComponent} from "./games/games.component";
import {GameDateilsComponent} from "./game-dateils/game-dateils.component";


const routes: Routes = [
  { path: '', redirectTo: '/genres', pathMatch: 'full' },
  {path: 'genres', component: GenresComponent},
  {path: 'genredetail/:id', component:GenresDetailComponent},
  {path: 'mechanics', component: MechanicsComponent},
  {path: 'register', component:RegisterComponent},
  {path: 'mechanicdetail/:id', component: MechanicDetailComponent},
  {path: 'login', component:LoginComponent},
  {path: 'other', component: OtherPageComponent},
  {path: 'games', component: GamesComponent},
  {path: 'gamedetail/:id', component: GameDateilsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
