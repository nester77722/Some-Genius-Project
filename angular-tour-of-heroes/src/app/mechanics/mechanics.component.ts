import { Component, OnInit } from '@angular/core';
import {Mechanic} from "../interfaces";
import {MechanicService} from "../mechanic.service";

@Component({
  selector: 'app-mechanics',
  templateUrl: './mechanics.component.html',
  styleUrls: ['./mechanics.component.css']
})
export class MechanicsComponent implements OnInit {
 mechanics?:Mechanic[];
  constructor(private mechanicService:MechanicService) { }

  ngOnInit(): void {
    this.mechanicService.getMechanics().subscribe(mechanics => this.mechanics = mechanics);
  }

}
