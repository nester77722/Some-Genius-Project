import { Component, OnInit } from '@angular/core';
import {Genre, Hero} from "../interfaces";
import {GenreService} from "../services/genre.service";
import {ImageService} from "../services/image.service";


@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  genres: Genre[] = [];



  constructor(private genreService: GenreService,
              private imageService:ImageService,) {
  }

  ngOnInit(): void {
    this.genreService.getGenres() .subscribe(genres => {
      genres.forEach(genre => genre.thumbnail = this.imageService.normalizeImage(genre.thumbnail))
      this.genres = genres
    });

  }

}
