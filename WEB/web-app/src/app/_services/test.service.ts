import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../_model';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private http: HttpClient) { }
  Get(){
    return this.http.get<string>('/api/test');
  }

}
