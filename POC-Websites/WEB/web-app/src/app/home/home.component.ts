 
import { Component, OnInit } from '@angular/core';
import { TestService, AuthenticationService } from '../_services';
 
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  message : any

  constructor(
   private authenticationService : AuthenticationService
  
  ) { }

  ngOnInit() {   
    this.authenticationService.test()
    .subscribe(response =>{
      this.message = response;
    });
     

  }

}
