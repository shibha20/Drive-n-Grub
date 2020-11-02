import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';

@Component({
  selector: 'app-signUpPage',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignUpPageComponent {

    constructor(private http: HttpClient, private nav: Services.NavigationService) { }
    email: string;
    firstName: string;
    lastName: string;
    passWord: number;
    customer = {
      CustomerId: 0,
      CustomerName: "",
      CustomerEmail: "",
      CustomerPassword: "",
      IsGuest: false,
      PhoneNumber:""
    };
    savedCustomer: any;
    business: any;
    validateCustomer: any;

    CreateCustomer(){
      this.customer.CustomerName = this.firstName + " " + this.lastName;
      this.http.get('http://localhost:5000/api/Customers/ValidateCustomer/'+ this.customer.CustomerEmail).subscribe(result=> {
        this.validateCustomer=result;
        if(result==false){
          this.http.post('http://localhost:5000/api/Customers', this.customer).subscribe(x => {
                  this.savedCustomer = x;
            });
        }
        else{

        }
      });
    }
    
}