import {Injectable} from '@angular/core';
import {Router} from '@angular/router';

@Injectable()
export class NavigationService{
    constructor(private router: Router)
    {}

    navigate(url: string){
        this.router.navigate([url]);
    }
}