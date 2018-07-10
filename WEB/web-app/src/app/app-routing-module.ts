import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./account/login/login.component";
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    { path: "**", component: LoginComponent },
    { path: "home", component: HomeComponent } ,   
    { path: "", component: LoginComponent }
];

export const routingComponents = [
    LoginComponent,
    HomeComponent
];
//Compile into on Ngmodule
@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
