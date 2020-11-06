import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BusinessLoginComponent } from './businesslogin/businesslogin.component';
import { BusinessPageComponent } from './businesspage/businesspage.component';
import { SignUpPageComponent } from './signup/signup-page.component';
import { WelcomePageComponent } from './welcome/welcome-page.component';

const routes: Routes = [
  { path: 'welcomePage', component: WelcomePageComponent },
  { path: 'signUpPage', component: SignUpPageComponent },
  { path: 'businesslogin', component: BusinessLoginComponent },
  { path: 'businesspage/:businessId', component: BusinessPageComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
