 
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./account";
import { HomeComponent } from './home';
import { AuthGuard } from "./_guards";
import { NavComponent } from "./nav";

const routes: Routes = [
 
    { path: "home", component: HomeComponent,  canActivate: [AuthGuard] } ,   
    { path: "", component: LoginComponent },
    { path: "**", component: LoginComponent }
];

export const routingComponents = [
    NavComponent,
    LoginComponent,
    HomeComponent
]; 
export const routing = RouterModule.forRoot(routes);
