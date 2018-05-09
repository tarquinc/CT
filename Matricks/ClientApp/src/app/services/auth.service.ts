import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthUser } from '../models/AuthUser';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private jwtHelperService: JwtHelperService) { }
  //constructor() { }

  //login(value) {
  //  const contentHeader = new HttpHeaders({ 'Content-type': 'application/json' });
  //  return this.http.post(this.baseUrl+"login", value, { headers: contentHeader })
  //}

  register(value) {
    const contentHeader = new HttpHeaders({ 'Content-type': 'application/json' });
    return this.http.post(this.baseUrl + "register", value);
  }

  login(user) {
    return this.http.post<AuthUser>(this.baseUrl + 'login', user).map((result: AuthUser) => {
      if (result) {
        localStorage.setItem('Token', result.token);
        localStorage.setItem('user', JSON.stringify(result.user));
      }
      return result;
    });
  }

  logout(user) {
        localStorage.removeItem('Token');
        localStorage.removeItem('user');
  }

  validLog() {
    return this.jwtHelperService.isTokenExpired();
  }
}
