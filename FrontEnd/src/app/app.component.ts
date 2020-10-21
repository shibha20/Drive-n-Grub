import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from './services/navigation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'FrontEnd';
  constructor(private http: HttpClient, private nav: Services.NavigationService) { }


  ngOnInit(): void{
    this.nav.navigate('welcomePage')
  }
}
