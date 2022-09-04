import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GenresComponent} from "./genres/genres.component";
import {GenresDetailComponent} from "./genres-detail/genres-detail.component";
import {MechanicsComponent} from "./mechanics/mechanics.component";
import {RegisterComponent} from "./register/register.component";

const routes: Routes = [
  { path: '', redirectTo: '/genres', pathMatch: 'full' },
  {path: 'genres', component: GenresComponent},
  {path: 'genredetail/:id', component:GenresDetailComponent},
  {path: 'mechanics', component: MechanicsComponent},
  {path: 'register', component:RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
