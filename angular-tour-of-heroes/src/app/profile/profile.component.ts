import { Component, OnInit } from '@angular/core';
import { User } from '../interfaces';
import { UserService } from '../services/user.service';
import { ImageService } from '../services/image.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: User | undefined;

  constructor(private userService: UserService, private imageService: ImageService) { }

  ngOnInit(): void {
    this.getUser();
  }

  updateInfo() {
    if (this.user) {
      this.userService.updateUserInfo(this.user).subscribe(() => {
        this.getUser();
        window.alert("Information updated!");
      })

    }
  }

  getUser() {
    this.userService.getUserInfo().subscribe(user => {
      user.image = this.imageService.normalizeImage(user.image);
      this.user = user;
    });
  }
  onAvatarChange(event: any) {
    if (this.user) {
      this.user.image = null;
      if (event.target.files && event.target.files.length > 0) {

        let file = event.target.files[0];

        let reader = new FileReader();

        reader.onload = () =>{
          if (this.user){
            this.user.image = reader.result?.toString();
          }
        }

        reader.readAsDataURL(file);
      }
    }
  }
}
