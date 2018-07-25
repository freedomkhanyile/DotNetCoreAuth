import { JwtInterceptor } from './_helpers/jwt-interceptor';
import { routingComponents,  routing } from './app-routing-module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppComponent } from './app.component';
import { ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './_helpers';

@NgModule({
   declarations: [
      AppComponent,
      routingComponents    
       
   ],
   imports: [
      BrowserModule,
      routing,
      ReactiveFormsModule,
      HttpClientModule,
      MDBBootstrapModule.forRoot()
     
  ],
  schemas: [NO_ERRORS_SCHEMA],
  providers: [
    {provide: HTTP_INTERCEPTORS,useClass : JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS,useClass : ErrorInterceptor, multi: true},

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
