import { Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private sanitizer: DomSanitizer) { }
  normalizeImage(image: any) {
    let objectURL = 'data:image/png;base64,' + image;
    this.sanitizer
    let result = this.sanitizer.bypassSecurityTrustUrl(objectURL);

    return result;
  }

  normalizeImageForServer(image: any) {
    if(typeof image === 'string'){
      let index = image.indexOf(",");
      return image.substring(index + 1);

    }
    else{
      let index = image.changingThisBreaksApplicationSecurity.indexOf(",");
      return image.changingThisBreaksApplicationSecurity.substring(index + 1);
    }

  }
}
