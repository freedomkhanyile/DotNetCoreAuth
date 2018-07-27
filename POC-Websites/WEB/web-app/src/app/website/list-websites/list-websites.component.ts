import { Component, OnInit } from '@angular/core';
import { WebsiteService } from '../../_services';
import { Observable } from '../../../../node_modules/rxjs';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: 'app-list-websites',
  templateUrl: './list-websites.component.html',
  styleUrls: ['./list-websites.component.scss']
})
export class ListWebsitesComponent implements OnInit {

  websites :  any[];
  template: string =`<img src="assets/img/loader.gif"/>`;
  constructor(
    private websiteService : WebsiteService,
    private spinnerService : Ng4LoadingSpinnerService
  ) { }

  ngOnInit() {
    //this.websites$ = this.websiteService.getWebsites();
 
    this.getWebsites();

  }

  getWebsites(){
    this.spinnerService.show();
    this.websiteService.getWebsites()
        .subscribe(res =>{
          this.websites = res;
          this.spinnerService.hide();  
        });
  }
}
