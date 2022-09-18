import { Component, OnInit } from '@angular/core';
import {Location} from "@angular/common";

@Component({
  selector: 'app-other-page',
  templateUrl: './other-page.component.html',
  styleUrls: ['./other-page.component.css']
})
export class OtherPageComponent implements OnInit {

  constructor(private location:Location) { }
  showText = false;
  timesClicked = 0;
  timeForOpen = 0;
  ngOnInit(): void {
  }
 goBack() : void{
    this.location.back()
 }
 buttonClicked(){
    let startTime = Date.now();
    setTimeout(() =>{
      this.showText = !this.showText;
      this.timesClicked++;
    },2000)
   this.timeForOpen = Date.now() - startTime;
   console.log(this.timeForOpen)
 }
  myText = '';
 getBackGroundColor(){
   if(this.myText == '1'){
     return "blue"
   }else {
     return "purple"
   }
 }

}
