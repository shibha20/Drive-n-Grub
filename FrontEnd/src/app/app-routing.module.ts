import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignUpPageComponent } from './signup/signup-page.component';
import { WelcomePageComponent } from './welcome/welcome-page.component';

const routes: Routes = [
  { path: 'welcomePage', component: WelcomePageComponent },
  { path: 'signUpPage', component: SignUpPageComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
