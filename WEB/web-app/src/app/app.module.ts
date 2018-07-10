import { routingComponents, AppRoutingModule } from './app-routing-module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';


@NgModule({
   declarations: [
      AppComponent,
      routingComponents,
      NavComponent,
       
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      MDBBootstrapModule.forRoot()
  ],
  schemas: [NO_ERRORS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
