import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule } from "@angular/forms";
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatCardModule} from '@angular/material/card'
import {MatDividerModule} from '@angular/material/divider';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import * as Services from './services';

import { WelcomePageComponent } from './welcome/welcome-page.component';
import { SignUpPageComponent } from './signup/signup-page.component';
import {ModalModule } from 'ngb-modal';
import { BusinessPageComponent } from './businesspage/businesspage.component';
import { BusinessLoginComponent } from './businesslogin/businesslogin.component';
import { ViewOrderComponent } from './orders/vieworder.component';
import { GuestPageComponent } from './guest/guest-page.component';
import { OrderPageComponent } from './orders/orderpage.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatTableModule} from '@angular/material/table';
import { ViewCartComponent } from './viewcart/viewcart.component';
import { CheckOutComponent } from './checkOut/checkOut.component';


@NgModule({
  declarations: [
    AppComponent,
    WelcomePageComponent,
    SignUpPageComponent,
    BusinessPageComponent,
    BusinessLoginComponent,
    ViewOrderComponent,
    GuestPageComponent,
    OrderPageComponent,
    ViewCartComponent,
    CheckOutComponent
  ],
  imports: [
    BrowserModule,

    MatInputModule,

    MatFormFieldModule,

    MatSidenavModule,

    AppRoutingModule,

    BrowserAnimationsModule,
    
    FormsModule,

    MatCardModule,
    
    HttpClientModule,

    ModalModule,

    MatDividerModule,

    MatExpansionModule,

    MatTableModule
    
  ],
  providers: [Services.NavigationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
