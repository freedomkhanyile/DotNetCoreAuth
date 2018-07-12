import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { API_URL } from '../_shared';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    rootUrl = API_URL;
    constructor(private http: HttpClient) { }

    login(username): Observable<any> {
        let data = { username: username };
        let reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' })
        return this.http.post(this.rootUrl + '/token', JSON.stringify(data), { headers: reqHeader });
    }
    logout() {
        localStorage.removeItem('currentUser');
    }
}
