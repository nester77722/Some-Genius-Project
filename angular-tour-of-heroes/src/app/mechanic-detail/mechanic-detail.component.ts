import { Component, OnInit } from '@angular/core';
import {Genre, Mechanic} from "../interfaces";
import {ActivatedRoute} from "@angular/router";
import {GenreService} from "../genre.service";
import {Location} from "@angular/common";
import {MechanicService} from "../mechanic.service";

@Component({
  selector: 'app-mechanic-detail',
  templateUrl: './mechanic-detail.component.html',
  styleUrls: ['./mechanic-detail.component.css']
})
export class MechanicDetailComponent implements OnInit {

  mechanic?:Mechanic;
  constructor( private route: ActivatedRoute,
               private mechanicService: MechanicService,
               private location: Location)
  { }


  ngOnInit(): void {
    this.getMechanic();
  }

  getMechanic(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id){
      this.mechanicService.getMechanic(id)
        .subscribe(mechanic => this.mechanic = mechanic);
    }

  }
  goBack(): void {
    this.location.back();
  }

}
