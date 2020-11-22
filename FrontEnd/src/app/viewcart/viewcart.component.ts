import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';
import { style } from '@angular/animations';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})
export class ViewCartComponent implements OnInit {
    @Output() cancel: EventEmitter<any> = new EventEmitter();
    @Output() save: EventEmitter<any> = new EventEmitter();
    constructor(private http: HttpClient, private nav: Services.NavigationService) { }
    itemsToOrder = [];
    displayedColumns: string[] = ['ItemName', 'Price',  'Remove'];

    ngOnInit(): void {
    }

    Cancel(){
        this.cancel.emit();
    }

    Save(){
        this.save.emit(this.itemsToOrder);
    }

    Remove(x: any)
    {
        var y = this.itemsToOrder.filter(q => q.itemId != x.itemId);
        this.itemsToOrder = [];
        this.itemsToOrder = y;
    }
}