import { Component, OnInit } from '@angular/core';
import { TestService } from '../_services';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  authorised: any;
  constructor(private testService: TestService) { }

  ngOnInit() {
    this.testService.Get().subscribe(response =>{
      this.authorised = response;
    });
  }

}
