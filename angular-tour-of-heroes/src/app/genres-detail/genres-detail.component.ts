import { Component, OnInit } from '@angular/core';
import {Genre} from '../interfaces';
import {GenreService} from "../services/genre.service";
import {ActivatedRoute} from "@angular/router";
import {Location} from "@angular/common";
import { DomSanitizer } from '@angular/platform-browser';
import {ImageService} from "../services/image.service";
@Component({
  selector: 'app-genres-detail',
  templateUrl: './genres-detail.component.html',
  styleUrls: ['./genres-detail.component.css']
})
export class GenresDetailComponent implements OnInit {
  genre?:Genre;
  image:any = null;
  thumbnail:any = null;
  constructor( private route: ActivatedRoute,
               private genreService: GenreService,
               private location: Location,
               private imageService:ImageService)
  { }


  ngOnInit(): void {
    this.getGenre();
  }

  getGenre(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id){
      this.genreService.getGenre(id)
        .subscribe(genre =>{
          this.genre = genre

          this.image = this.imageService.normalizeImage(genre.image);

          this.thumbnail = this.imageService.normalizeImage(genre.thumbnail);
        });
    }

  }


}
