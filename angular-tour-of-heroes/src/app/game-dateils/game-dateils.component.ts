import { Component, OnInit } from '@angular/core';
import {Game} from "../interfaces";
import {GameService} from "../services/game.service";
import {ActivatedRoute} from "@angular/router";
import {GenreService} from "../services/genre.service";
import {Location} from "@angular/common";

@Component({
  selector: 'app-game-dateils',
  templateUrl: './game-dateils.component.html',
  styleUrls: ['./game-dateils.component.css']
})
export class GameDateilsComponent implements OnInit {
  game?:Game;
  constructor(private route: ActivatedRoute,
              private gameService: GameService,
              private location: Location) { }

  ngOnInit(): void {
  }
  getGame(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id){
      this.gameService.getGame(id)
        .subscribe(game => this.game = game);
    }

  }
  goBack(): void {
    this.location.back();
  }
}
