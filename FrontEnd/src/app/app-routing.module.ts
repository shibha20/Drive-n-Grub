import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BusinessLoginComponent } from './businesslogin/businesslogin.component';
import { BusinessPageComponent } from './businesspage/businesspage.component';
import { ViewOrderComponent } from './orders/vieworder.component';
import { GuestPageComponent } from './guest/guest-page.component';
import { SignUpPageComponent } from './signup/signup-page.component';
import { WelcomePageComponent } from './welcome/welcome-page.component';
import { OrderPageComponent } from './orders/orderpage.component';
import { CheckOutComponent } from './checkOut/checkOut.component';

const routes: Routes = [
  { path: 'welcomePage', component: WelcomePageComponent },
  { path: 'signUpPage', component: SignUpPageComponent },
  { path: 'businesslogin', component: BusinessLoginComponent },
  { path: 'businesspage/:businessId', component: BusinessPageComponent },
  { path: 'vieworder', component: ViewOrderComponent},
  { path: 'guestPage', component: GuestPageComponent },
  { path: 'orderMenu/:customerId', component: OrderPageComponent },
  { path: 'orderMenu/:customerId/checkOut/:orderId', component: CheckOutComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { } 
