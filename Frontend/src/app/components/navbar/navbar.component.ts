import { Component, OnInit, ElementRef } from '@angular/core';
import { AFROUTES,EMROUTES,CLROUTES } from '../sidebar/sidebar.component';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public focus;
  public listTitles: any[];
  public location: Location;
  constructor(location: Location,  private element: ElementRef, private router: Router, private local: StorageService) {
    this.location = location;
  }

  ngOnInit() {
    if(this.local.getData('userType') === 'affiliate'){
      this.listTitles = AFROUTES.filter(listTitle => listTitle);
    }else if(this.local.getData('userType') === 'employee'){
      this.listTitles = EMROUTES.filter(listTitle => listTitle);
    }else{
      this.listTitles = CLROUTES.filter(listTitle => listTitle);
    }
  }
  getTitle(){
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if(titlee.charAt(0) === '#'){
        titlee = titlee.slice( 1 );
    }

    for(var item = 0; item < this.listTitles.length; item++){
        if(this.listTitles[item].path === titlee){
            return this.listTitles[item].title;
        }
    }
    return 'Dashboard';
  }

}
