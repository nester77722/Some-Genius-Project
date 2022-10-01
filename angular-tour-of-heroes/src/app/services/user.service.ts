import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenService } from './token.service';
import { User } from '../interfaces';
import { Config } from '../Config';
import { Observable } from 'rxjs';
import { ImageService } from './image.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = Config.apiUrl;
  private userUrl = 'api/user'
  constructor(
    private httpClient: HttpClient,
    private tokenService: TokenService,
    private imageService: ImageService) { }

  getUserInfo(): Observable<User> {

    let userId = this.tokenService.getUserId();

    if (!userId) {
      throw new Error('Something wrong with local storage');
    }

    const url = this.apiUrl + '/' + this.userUrl;

    return this.httpClient.get<User>(url);
  }

  updateUserInfo(user: User): Observable<any> {
    const url = this.apiUrl + '/' + this.userUrl;

    let image = this.imageService.normalizeImageForServer(user.image);

    let formData = new FormData();

    formData.append("id", user.id);
    formData.append("userName", user.userName)
    formData.append("image", image);
    formData.append("age", user.age.toString());
    formData.append("name", user.name);
    formData.append("surname", user.surname);

    return this.httpClient.put(url, formData);
  }
}
