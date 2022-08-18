import { Component, OnInit } from '@angular/core';
import {Genre} from '../interfaces';
import {GenreService} from "../genre.service";
import {ActivatedRoute} from "@angular/router";
import {HeroService} from "../hero.service";
import {Location} from "@angular/common";

@Component({
  selector: 'app-genres-detail',
  templateUrl: './genres-detail.component.html',
  styleUrls: ['./genres-detail.component.css']
})
export class GenresDetailComponent implements OnInit {
  genre?:Genre;
  constructor( private route: ActivatedRoute,
               private genreService: GenreService,
               private location: Location)
  { }


  ngOnInit(): void {
    this.getGenre();
  }

  getGenre(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id){
      this.genreService.getGenre(id)
        .subscribe(genre => this.genre = genre);
    }

  }
  goBack(): void {
    this.location.back();
  }

}
