import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as Services from '../services/navigation.service';

@Component({
  selector: 'app-businesslogin',
  templateUrl: './businesslogin.component.html',
  styleUrls: ['./businesslogin.component.css']
})
export class BusinessLoginComponent implements OnInit {
  
    constructor(private http: HttpClient, private nav: Services.NavigationService) { }
    business: any;
    email: string;
    password: string;

    ngOnInit(): void {

    }

    Back(){
      this.nav.navigate('welcomePage');
    }

    Login(){
      this.http.get('http://localhost:5000/api/Businesses/GetByEmailAndPassword/' + this.email + '/' + this.password).subscribe(x => {
        this.business = x;
        if(this.business != 'undefined')
        {
          //Got to Next Page
          this.nav.navigate('businesspage/' + this.business.businessId)
        }
        else{
          alert("This Business Does Not Exist");
        }
      });
    }

}