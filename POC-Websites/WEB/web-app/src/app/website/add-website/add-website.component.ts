import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-website',
  templateUrl: './add-website.component.html',
  styleUrls: ['./add-website.component.scss']
})
export class AddWebsiteComponent implements OnInit {
  cardForm: FormGroup;
  constructor(private fb: FormBuilder) { 
    this.cardForm = fb.group({
      validateName : ['', Validators.required, Validators.minLength(5)],
      validateDescription : ['', Validators.required],
      validateUrl : ['', Validators.required]
    });
  }

  ngOnInit() {
  }

}
