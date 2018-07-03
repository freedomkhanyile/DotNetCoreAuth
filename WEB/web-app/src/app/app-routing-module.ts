import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./account/login/login.component";

const routes : Routes = [
    { path: "**", component: LoginComponent},    
    { path: "", component: LoginComponent}
];

export const routingComponents = [
    LoginComponent
];
//Compile into on Ngmodule
@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
