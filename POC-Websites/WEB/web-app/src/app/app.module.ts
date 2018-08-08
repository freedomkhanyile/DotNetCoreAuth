import { AuthenticationService } from './_services/authentication.service';
import { JwtInterceptor } from './_helpers/jwt-interceptor';
import { routingComponents, routing } from './app-routing-module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './_helpers';
import { WebsiteService } from './_services';
import { ToastrModule } from 'ngx-toastr';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import {PaginatorModule} from 'primeng/paginator'; 
import { WebsitePipe } from './_shared';
import { Ng2SearchPipeModule } from 'ng2-search-filter'; //importing the module
import {NgxPaginationModule} from 'ngx-pagination';
 
@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    WebsitePipe
  ],
  imports: [
    BrowserModule,
    routing,
    ReactiveFormsModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    ToastrModule,
    Ng4LoadingSpinnerModule ,
    PaginatorModule,
    Ng2SearchPipeModule,
    NgxPaginationModule
  ],
  schemas: [NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthenticationService,
    WebsiteService,
 
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
