import { HTTP_INTERCEPTORS, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

import { TokenService } from '../services/token.service';
import { AuthService } from '../services/auth.service';

import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, filter, switchMap, take } from 'rxjs/operators';
import { Tokens } from '../interfaces';

const TOKEN_HEADER_KEY = 'Authorization';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(private tokenService: TokenService, private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<Object>> {
    let authReq = req;
    const token = this.tokenService.getTokens();
    if (token != null) {
      authReq = this.addTokenHeader(req, token.accessToken);
    }

    return next.handle(authReq).pipe(catchError(error => {
      if (error instanceof HttpErrorResponse && !authReq.url.includes('auth/signin') && error.status === 401 && token) {
        return this.handle401Error(authReq, next);
      }

      return throwError(error);
    }));
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
    if (!this.isRefreshing) {
      console.log("interceptor is trying to refresh");
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      const tokens = this.tokenService.getTokens();

      if (tokens)
        return this.authService.refresh(tokens).pipe(
          switchMap((newTokens: Tokens) => {
            this.isRefreshing = false;

            this.tokenService.saveTokens(newTokens);
            this.refreshTokenSubject.next(newTokens.accessToken);

            return next.handle(this.addTokenHeader(request, newTokens.accessToken));
          }),
          catchError((err) => {
            this.isRefreshing = false;

            this.tokenService.deleteTokens();

            console.log("interceptor refreshing failed");
            return throwError(err);
          })
        );
    }

    return this.refreshTokenSubject.pipe(
      filter(token => token !== null),
      take(1),
      switchMap((token) => next.handle(this.addTokenHeader(request, token)))
    );
  }

  private addTokenHeader(request: HttpRequest<any>, token: string) {
    return request.clone({ headers: request.headers.set(TOKEN_HEADER_KEY, 'Bearer ' + token) });
  }
}

export const authInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
];