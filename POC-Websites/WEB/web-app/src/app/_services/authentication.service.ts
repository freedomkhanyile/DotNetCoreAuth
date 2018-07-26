import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { auth_api_url } from '../_shared';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    rootUrl = auth_api_url;
    constructor(private http: HttpClient) { }

    login(username): Observable<any> {
        let data = { username: username };
        let reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' })
        return this.http.post(this.rootUrl + '/token', JSON.stringify(data), { headers: reqHeader });
    }

    test(): Observable<any>{
        return this.http.get(this.rootUrl + "/token/test");
    }
    logout() {
        localStorage.removeItem('currentUser');
    }
}
