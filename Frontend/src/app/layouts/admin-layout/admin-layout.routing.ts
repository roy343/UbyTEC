import { Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { AfProductComponent } from '../../pages/af-product/af-product.component';
import { AfOrderComponent } from '../../pages/af-order/af-order.component';
import { CartComponent } from '../../pages/cart/cart.component';
import { CheckoutComponent } from '../../pages/checkout/checkout.component';
import { ClientStoresComponent } from '../../pages/client-stores/client-stores.component';
import { DeliveryComponent } from '../../pages/delivery/delivery.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'afi/afproducts', component: AfProductComponent },
    { path: 'aforders',       component: AfOrderComponent },
    { path: 'cart',           component: CartComponent },
    { path: 'checkout',       component: CheckoutComponent },
    { path: 'stores',         component: ClientStoresComponent },
    { path: 'delivery',       component: DeliveryComponent }
];
