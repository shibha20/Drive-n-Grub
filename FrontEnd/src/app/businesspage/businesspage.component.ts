import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap'
import { AnimationDriver } from '@angular/animations/browser';
import { ViewOrderComponent } from '../orders/vieworder.component';



@Component({
  selector: 'app-businesspage',
  templateUrl: './businesspage.component.html',
  styleUrls: ['./businesspage.component.css']
})
export class BusinessPageComponent implements OnInit {
  
  constructor(private http: HttpClient, private nav: Services.NavigationService, private modalService: NgbModal,) { }
  orders: any;
  completedOrders = [];
  incomingOrders = [];
  preppingOrders = [];
  pickedUpOrders = [];
  orderItems: any;

  modalOptions: NgbModalOptions = {
    size: 'xl',
    backdrop: 'static',
    scrollable: true,
    centered: true
  }

  ngOnInit(): void {
    this.http.get('http://localhost:5000/api/Orders/OpenOrders').subscribe(x => {
      this.orders = x;
      this.orders.forEach(element => {
        if(element.statusTypeId == 1)
        {
          this.incomingOrders.push(element);
        }
        else if(element.statusTypeId == 2){
          this.preppingOrders.push(element);
        }
        else if(element.statusTypeId == 3){
          this.completedOrders.push(element);
        }
        else{
          this.pickedUpOrders.push(element);
        }         
      });
    });
  }

  ChangeStatus(element: any)
  {
    element.statusTypeId = element.statusTypeId + 1;
    if(element.statusTypeId == 1)
    {
      this.incomingOrders.push(element);
    }
    else if(element.statusTypeId == 2){
      this.incomingOrders = this.incomingOrders.filter(x=>x.orderId != element.orderId);
      this.preppingOrders.push(element);
    }
    else if(element.statusTypeId == 3){
      this.preppingOrders = this.preppingOrders.filter(x=>x.orderId != element.orderId);
      this.completedOrders.push(element);
    }
    else{
      this.completedOrders.splice(element);
      this.pickedUpOrders.push(element);
    }
      
    this.http.put('http://localhost:5000/api/Orders', element).subscribe(x => {

    });
  }

  View(element: any){   

    const modalRef = this.modalService.open(ViewOrderComponent, this.modalOptions);
    modalRef.componentInstance.order = element;
    modalRef.componentInstance.cancel.subscribe(() => {modalRef.close();});
  }

  SignOut(){
    this.nav.navigate('welcomePage')
  }

}