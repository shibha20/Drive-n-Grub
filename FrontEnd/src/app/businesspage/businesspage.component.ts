import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';

@Component({
  selector: 'app-businesspage',
  templateUrl: './businesspage.component.html',
  styleUrls: ['./businesspage.component.css']
})
export class BusinessPageComponent implements OnInit {
  
  constructor(private http: HttpClient, private nav: Services.NavigationService) { }

  ngOnInit(): void {
        
  }

}