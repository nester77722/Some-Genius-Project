import { Component, OnInit } from '@angular/core';
import {Genre, Hero} from "../interfaces";
import {GenreService} from "../services/genre.service";


@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  genres: Genre[] = [];



  constructor(private genreService: GenreService) {

  }

  ngOnInit(): void {
    this.genreService.getGenres() .subscribe(genres => this.genres = genres);

  }

}
