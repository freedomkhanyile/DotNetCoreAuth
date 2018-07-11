import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable({  providedIn: 'root'})
export class AuthenticationService {

constructor(private http : HttpClient) {}

      login(User : any) {
          return this.http.post<any>('/api/authenticate', User )
            .pipe(map((res:any) => {
                // login successful if there's a jwt token in the response
                if (res && res.token) {
                    // store jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ token: res.token }));
                }                
            }))
      }
      logout(){
          localStorage.removeItem('currentUser');
      }
}
