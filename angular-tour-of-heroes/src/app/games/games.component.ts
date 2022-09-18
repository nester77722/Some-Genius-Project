import { Component, OnInit } from '@angular/core';
import {Game} from "../interfaces";
import {GameService} from "../services/game.service";

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
games:Game[] = [];
  constructor(private gameService:GameService) { }

  ngOnInit(): void {
    this.gameService.getGames().subscribe(response => {
      this.games = response;
    })
  }

}
