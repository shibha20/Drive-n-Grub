import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';
import { style } from '@angular/animations';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-vieworder',
  templateUrl: './vieworder.component.html',
  styleUrls: ['./vieworder.component.css']
})
export class ViewOrderComponent implements OnInit {
    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<any> = new EventEmitter();
    constructor(private http: HttpClient, private nav: Services.NavigationService) { }
    orderItems: any;
    order: any


    ngOnInit(): void {
        this.http.get('http://localhost:5000/api/OrderItems/GetAllByOrderId/' + this.order.orderId).subscribe(x => {
            this.orderItems = x;
          });
    }

    Cancel(){
        this.cancel.emit();
    }


}