import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { website_api_url } from '../_shared';
 

@Injectable({
  providedIn: 'root'
})
export class WebsiteService {

  rootUrl = website_api_url;

  constructor(private http: HttpClient) { }

  getWebsites(): Observable<any> {
    return this.http.get<any>(this.rootUrl + '/website/GetWebsites');
  }
  
  addWebsite(data): Observable<any>{
    let reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' })
    return this.http.post(this.rootUrl + '/website/AddWebsite', JSON.stringify(data), { headers: reqHeader });
  }
}
