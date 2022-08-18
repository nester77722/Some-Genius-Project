import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroesComponent } from './heroes/heroes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import {GenresComponent} from "./genres/genres.component";
import {GenresDetailComponent} from "./genres-detail/genres-detail.component";
import {MechanicsComponent} from "./mechanics/mechanics.component";

const routes: Routes = [
  { path: 'heroes', component: HeroesComponent },
  {path: 'dashboard', component:DashboardComponent},
  { path: '', redirectTo: '/genres', pathMatch: 'full' },
  {path: 'detail/:id', component: HeroDetailComponent},
  {path: 'genres', component: GenresComponent},
  {path: 'genredetail/:id', component:GenresDetailComponent},
  {path: 'mechanics', component: MechanicsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
