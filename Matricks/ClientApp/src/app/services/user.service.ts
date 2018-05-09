import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { DTOCopy } from '../models/DTOCopy';

@Injectable()
export class UserService {

  constructor(public http: HttpClient) { }

  baseUrl = environment.apiUrl;

  getAll() {

    return this.http.get<Array<DTOCopy>>(this.baseUrl + '/users/users');

  }

}
