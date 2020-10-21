import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';

@Component({
  selector: 'app-welcomePage',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css']
})
export class WelcomePageComponent implements OnInit {

    constructor(private http: HttpClient, private nav: Services.NavigationService) { }
    email: string;
    passWord: number;
    customer: any;
    business: any;


    ngOnInit(): void {

    }

    CustomerLogin(e:any){
      this.http.get('http://localhost:5000/api/customers/GetByEmailAndPassword/' + this.email + '/' + this.passWord).subscribe(x => {
        this.customer = x;
        if(this.customer != 'undefined')
        {
          //Got to Next Page
          this.nav.navigate('OrderMenu/' + this.customer.customerId)
        }
      });
    }

    BusinessLogin(e:any){
      this.http.get('http://localhost:5000/api/business/GetByEmailAndPassword/' + this.email + '/' + this.passWord).subscribe(x => {
        this.business = x;
        if(this.business != 'undefined')
        {
          //Got to Next Page
          this.nav.navigate('BusinessPage/' + this.business.businessId)
        }
      }); 
    }

    GuestLogin(e:any){
      //Got to Next Page
      this.nav.navigate('GuestPage')
    }

    SignUp(e:any){
      //Got to Next Page
      this.nav.navigate('SignUpPage')
    }

}