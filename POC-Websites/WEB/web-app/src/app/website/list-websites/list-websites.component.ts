import { Component, OnInit, ViewChildren, ElementRef,QueryList } from '@angular/core';
import { WebsiteService } from '../../_services';
import { Observable } from '../../../../node_modules/rxjs';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
 

@Component({
  selector: 'app-list-websites',
  templateUrl: './list-websites.component.html',
  styleUrls: ['./list-websites.component.scss']
})
export class ListWebsitesComponent implements OnInit {
  @ViewChildren('pages') pages: QueryList<any>;
  itemsPerPage = 5;
  numberOfVisiblePaginators = 10;
  numberOfPaginators = 10;
  paginators: Array<any> = [];
  activePage = 1;
  firstVisibleIndex = 1;
  lastVisibleIndex: number = this.itemsPerPage;
  firstVisiblePaginator = 0;
  lastVisiblePaginator = this.numberOfVisiblePaginators;
  websites: any[];
  template = `<img src="assets/img/loader.gif"/>`;
  searchText: any
  constructor(
    private websiteService: WebsiteService,
    private spinnerService: Ng4LoadingSpinnerService,
    private el: ElementRef
  ) { }

  ngOnInit() { 
    this.getWebsites();
  }

  getWebsites() {
    this.spinnerService.show();
    this.websiteService.getWebsites()
      .subscribe(res => {
        this.websites = res;
        // this.addPaginators();
        this.spinnerService.hide();
      });
  }
}
