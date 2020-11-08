import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';

@Component({
  selector: 'app-guestPage',
  templateUrl: './guest-page.component.html',
  styleUrls: ['./guest-page.component.css']
})
export class GuestPageComponent {

    constructor(private http: HttpClient, private nav: Services.NavigationService) { }
    firstName: string = null;
    lastName: string = null;
    customer = {
      CustomerId: 0,
      CustomerName: null,
      CustomerEmail: null,
      CustomerPassword: "",
      IsGuest: true,
      PhoneNumber:null
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
                  this.nav.navigate('orderMenu/' + this.savedCustomer.customerId);
            });
        }
        else{
          alert("This Email Has An Account");
        }
      });
    }

    Back(){
      this.nav.navigate('welcomePage');
    }

}