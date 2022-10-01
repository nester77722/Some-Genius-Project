import { Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private sanitizer:DomSanitizer) { }
  normalizeImage(image:any){
    let objectURL = 'data:image/png;base64,' + image;
    return this.sanitizer.bypassSecurityTrustUrl(objectURL);
  }
}
