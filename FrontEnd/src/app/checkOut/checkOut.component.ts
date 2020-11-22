import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-checkOut',
  templateUrl: './checkOut.component.html',
  styleUrls: ['./checkOut.component.css']
})
export class CheckOutComponent implements OnInit {
  
    constructor(
        private http: HttpClient, 
        private nav: Services.NavigationService, 
        private route: ActivatedRoute,
        //private modalService: NgbModal,
        ) { }
    customer: any;
    orderId: number;
    customerId: number;
    order: any;

    ngOnInit(): void {
        this.route.params.subscribe(params =>{
            if(params['customerId'] != null){
                this.customerId =+ params['customerId']
            }
        });
        this.route.params.subscribe(params =>{
            if(params['orderId'] != null){
                this.orderId =+ params['orderId']
            }
        });

        this.http.get('http://localhost:5000/api/Orders/' + this.orderId).subscribe(x => {
            this.order = x;
        });

        this.http.get('http://localhost:5000/api/Customers/' + this.customerId).subscribe(x => {
            this.customer = x;
        });

    }

    Back(){
      this.nav.navigate('welcomePage');
    }

    Proceed(){
        alert("Thank you for your order! A text will be sent when ready!");
        if(this.customer.isGuest)
        {
            this.http.delete('http://localhost:5000/api/Customers/' + this.customerId).subscribe(x => {
                this.nav.navigate('welcomePage');
            }); 
        }
    }

}