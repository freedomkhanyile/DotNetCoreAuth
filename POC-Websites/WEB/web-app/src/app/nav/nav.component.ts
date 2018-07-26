import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  user : any
  constructor() { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem("currentUser"));
  }

}
