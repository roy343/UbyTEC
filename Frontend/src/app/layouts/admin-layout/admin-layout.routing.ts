import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { AfProductComponent } from '../../pages/af-product/af-product.component';
import { AfOrderComponent } from '../../pages/af-order/af-order.component';
import { CartComponent } from '../../pages/cart/cart.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'afproducts',     component: AfProductComponent },
    { path: 'aforders',       component: AfOrderComponent },
    { path: 'cart',       component: CartComponent }
];
