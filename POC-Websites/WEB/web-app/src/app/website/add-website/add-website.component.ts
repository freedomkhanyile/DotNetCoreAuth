import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { WebsiteService } from '../../_services';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-add-website',
  templateUrl: './add-website.component.html',
  styleUrls: ['./add-website.component.scss']
})
export class AddWebsiteComponent implements OnInit {
  cardForm: FormGroup;
  name: any
  description: any
  url: any
  message: any
  publisher: any
  error = ''
  submitted = false

  constructor(private fb: FormBuilder,
     private websiteService : WebsiteService
    ,private router: Router) {

  }
  get f() { return this.cardForm.controls; }

  ngOnInit() {
    this.cardForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      url: ['', Validators.required]
    });
    this.publisher = JSON.parse(localStorage.getItem('currentUser'))
    // alert(this.publisher.username)
  }

  add() {
    this.submitted = true;
    if (this.cardForm.invalid) {
      return;
    }
 
    let data = {
      name: this.f.name.value,
      description: this.f.description.value,
      url: this.f.url.value,
      publisher: this.publisher.username
    }

    this.websiteService.addWebsite(data)
      .subscribe(response => {
        if(response){
          alert(response.message)
          this.router.navigate(["home"])
        }
      },
      error => {
        this.error = error
        console.log(this.error); 
      })
  
    // console.log(data)
  }
}
