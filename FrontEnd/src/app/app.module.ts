import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule } from "@angular/forms";
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatCardModule} from '@angular/material/card'
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import * as Services from './services';

import { WelcomePageComponent } from './welcome/welcome-page.component';
import {ModalModule } from 'ngb-modal';


@NgModule({
  declarations: [
    AppComponent,
    WelcomePageComponent
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

    ModalModule
  ],
  providers: [Services.NavigationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
