 
import { Component, OnInit } from '@angular/core';
import { TestService, AuthenticationService } from '../_services';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  message : any

  constructor(
   private authenticationService : AuthenticationService,
   private toast : ToastrService
  ) { }

  ngOnInit() {   
    this.authenticationService.test()
    .subscribe(response =>{
      this.message = response;
    });
    this.toast.success('Logged in', 'User Successfully Authenticated');
  }

}
