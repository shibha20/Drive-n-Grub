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

    CustomerLogin(){
      this.http.get('http://localhost:5000/api/customers/GetByEmailAndPassword/' + this.email + '/' + this.passWord).subscribe(x => {
        this.customer = x;
        if(this.customer != null)
        {
          //Got to Next Page
          this.nav.navigate('orderMenu/' + this.customer.customerId)
        }
        else{
          alert("This User Does Not Exist");
        }
      });
    }

    BusinessLogin(){
      //Got to Next Page
      this.nav.navigate('businesslogin')
 
    }

    GuestLogin(){
      //Got to Next Page
      this.nav.navigate('guestPage')
    }

    SignUp(){
      //Got to Next Page
      this.nav.navigate('signUpPage')
    }

}