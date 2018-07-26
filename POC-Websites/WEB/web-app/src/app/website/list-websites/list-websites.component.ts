import { Component, OnInit } from '@angular/core';
import { WebsiteService } from '../../_services';
import { Observable } from '../../../../node_modules/rxjs';

@Component({
  selector: 'app-list-websites',
  templateUrl: './list-websites.component.html',
  styleUrls: ['./list-websites.component.scss']
})
export class ListWebsitesComponent implements OnInit {

  websites$ : Observable<any[]>;

  constructor(
    private websiteService : WebsiteService
  ) { }

  ngOnInit() {
    debugger
    this.websites$ = this.websiteService.getWebsites();
  }

}
