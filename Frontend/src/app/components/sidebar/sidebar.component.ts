import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const AFROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'ni-tv-2 text-primary', class: '' },
    { path: '/icons', title: 'Icons',  icon:'ni-planet text-blue', class: '' },
    { path: '/maps', title: 'Maps',  icon:'ni-pin-3 text-orange', class: '' },
    { path: '/user-profile', title: 'User profile',  icon:'ni-single-02 text-yellow', class: '' },
    { path: '/tables', title: 'Tables',  icon:'ni-bullet-list-67 text-red', class: '' },
    { path: '/login', title: 'Login',  icon:'ni-key-25 text-info', class: '' },
    { path: '/register', title: 'Register',  icon:'ni-circle-08 text-pink', class: '' }
];
export const CLROUTES: RouteInfo[] = [

    { path: '/user-profile', title: 'User profile',  icon:'ni-single-02 text-yellow', class: '' },
    { path: '/tables', title: 'Tables',  icon:'ni-bullet-list-67 text-red', class: '' },
    { path: '/login', title: 'Login',  icon:'ni-key-25 text-info', class: '' },
    { path: '/register', title: 'Register',  icon:'ni-circle-08 text-pink', class: '' }
];
export const EMROUTES: RouteInfo[] = [
    { path: '/employee-list', title: 'Empleados',  icon: 'ni-tv-2 text-primary', class: '' },
    { path: '/deliverer-list', title: 'Repartidores',  icon:'ni-planet text-blue', class: '' },
    { path: '/affiliate-list', title: 'Afiliados',  icon:'ni-pin-3 text-green', class: '' },
    { path: '/affiliations', title: 'Solicitudes de Afiliacion',  icon:'ni-pin-3 text-yellow', class: '' },
    { path: '/business-list', title: 'Tipos de Comercio',  icon:'ni-single-02 text-orange', class: '' },
    { path: '/reports', title: 'Reportes',  icon:'ni-bullet-list-67 text-red', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;
  currentUser: Object = {};

  constructor(private router: Router) { }

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem('user'));

    console.log(localStorage.getItem('userType'));
    if (localStorage.getItem('userType') == 'affiliate') {
      this.menuItems = AFROUTES.filter(menuItem => menuItem);
    } else if (localStorage.getItem('userType') == 'employee') {
      this.menuItems = EMROUTES.filter(menuItem => menuItem);
    } else {
      this.menuItems = CLROUTES.filter(menuItem => menuItem);
    }
    console.log(this.menuItems);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }
}
