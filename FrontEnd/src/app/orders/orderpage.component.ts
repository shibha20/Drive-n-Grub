import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';
import { style } from '@angular/animations';
import { NgbModal,NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute } from '@angular/router';
import { ViewCartComponent } from '../viewcart/viewcart.component';


@Component({
  selector: 'app-orderpage',
  templateUrl: './orderpage.component.html',
  styleUrls: ['./orderpage.component.css']
})
export class OrderPageComponent implements OnInit {
    constructor(
        private http: HttpClient, 
        private nav: Services.NavigationService, 
        private route: ActivatedRoute,
        private modalService: NgbModal,
        ) { }
    orderItems: any;
    customerId: number;
    isProcessing: boolean;
    itemTypes: any;
    sizes: any;
    price: number;
    tax: number;
    total: number;
    panelOpenState = false;
    items: any;
    itemsToOrder = [];
    displayedColumns: string[] = ['ItemName','Price',  'Add'];
    itemsToOrderLength = 0;
    order = {
        OrderId: 0,
        CustomerId: 0,
        TotalPrice: 0,
        Tax: 0,
        Discount: 0,
        StatusTypeId: 1
    };
    savedOrder: any;
    orderItem = {
        OrderItemId: 0,
        OrderId: 0,
        ItemId: 0
    };
    orderItemsToSave = [];
    modalOptions: NgbModalOptions = {
        size: 'xl',
        backdrop: 'static',
        centered: true
      }

    ngOnInit(): void {
        this.route.params.subscribe(params =>{
            if(params['customerId'] != null){
                this.customerId =+ params['customerId']
            }
        });

        this.price = 0.00;
        this.tax = 0.00;
        this.total = 0.00;

        this.http.get('http://localhost:5000/api/ItemTypes').subscribe(x => {
            this.itemTypes = x;
          });
          this.GetSizes();
    }

    GetSizes(){
        this.http.get('http://localhost:5000/api/Sizes').subscribe(x => {
          this.sizes = x;
        });
    }

    OpenItems(x: any){
        this.items = [];
        //var itemTypeId = this.itemTypes.find(x => x.itemTypeName == 'Starters').itemTypeId;
        this.http.get('http://localhost:5000/api/Items/GetItemByItemTypeId/' + x.itemTypeId).subscribe(x => {
          this.items = x;
          this.items.forEach(element => {
             if(element.itemId == 3)
             {
                 element.size = this.sizes.filter(x => x.sizeId == element.sizeId);
             } 
          });
        });
    }

    AddItem(item: any){
        this.itemsToOrder.push(item);
        this.AddPrice();
        this.itemsToOrderLength = this.itemsToOrder.length;
    }

    AddPrice(){
        this.price = 0;
        this.tax = 0;
        this.total = 0;
        this.itemsToOrder.forEach((x) => {
          this.price = Math.round((this.price + x.price)*100)/100;
          if(x.itemTypeId == 3 || x.itemTypeId == 4)
          {
            this.tax = Math.round(((x.price * 0.0575) + this.tax)*100)/100;
          }
          this.total = Math.round((this.price + this.tax)*100)/100;
        });
    }

    CheckOut()
    {
        this.isProcessing = true;
        this.orderItemsToSave = [];
        this.order.CustomerId = this.customerId;
        this.order.TotalPrice = this.total;
        this.order.Tax = this.tax;
        this.order.Discount = 0;
        this.order.StatusTypeId = 1;
        this.order.OrderId = 0;
        this.http.post('http://localhost:5000/api/Orders', this.order).subscribe(x => {
          this.savedOrder = x;
          this.itemsToOrder.forEach(element => {
            this.orderItem = {
              ItemId: element.itemId,
              OrderId: this.savedOrder.orderId,
              OrderItemId: 0
            };
            this.orderItemsToSave.push(this.orderItem);
          });
          this.http.post('http://localhost:5000/api/OrderItems/CreateListOfOrderItems', this.orderItemsToSave).subscribe(x => {
            this.nav.navigate('orderMenu/' + this.customerId + '/checkOut/'+ this.savedOrder.orderId);
            this.isProcessing = false;
          });
        });
    }

    SignOut()
    {
        this.nav.navigate('welcomePage');
    }

    ViewCart()
    {
        const modalRef = this.modalService.open(ViewCartComponent, this.modalOptions);
        modalRef.componentInstance.itemsToOrder = this.itemsToOrder;
        modalRef.componentInstance.cancel.subscribe(() => {modalRef.close();});
        modalRef.componentInstance.save.subscribe((x) => {
          modalRef.close();
          this.itemsToOrder = [];
          this.itemsToOrder = x;
          this.itemsToOrderLength = this.itemsToOrder.length;
          this.AddPrice(); 
        });
    }

}