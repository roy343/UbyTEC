import { Routes } from '@angular/router';

<<<<<<< Updated upstream

=======
//import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
//import { IconsComponent } from '../../pages/icons/icons.component';
>>>>>>> Stashed changes
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { AfProductComponent } from '../../pages/af-product/af-product.component';
import { AfOrderComponent } from '../../pages/af-order/af-order.component';
import { CartComponent } from '../../pages/cart/cart.component';
import { CheckoutComponent } from '../../pages/checkout/checkout.component';
import { BusinessAdminComponent } from 'src/app/pages/affiliate-admin/business-admin.component';
import { AffiliateListComponent } from 'src/app/pages/affiliate-list/affiliate-list.component';
import { AffiliatesComponent } from 'src/app/pages/affiliates/affiliates.component';
import { AffiliationsComponent } from 'src/app/pages/affiliations/affiliations.component';
import { BusinessComponent } from 'src/app/pages/business/business.component';
import { BusinessListComponent } from 'src/app/pages/business-list/business-list.component';
import { DelivererListComponent } from 'src/app/pages/deliverer-list/deliverer-list.component';
import { DeliverersComponent } from 'src/app/pages/deliverers/deliverers.component';
import { EmployeeListComponent } from 'src/app/pages/employee-list/employee-list.component';
import { EmployeesComponent } from 'src/app/pages/employees/employees.component';
import { ReportsComponent } from 'src/app/pages/reports/reports.component';
import { ClientHomeComponent } from 'src/app/pages/client-home/client-home.component';
import { ClientStoresComponent} from 'src/app/pages/client-stores/client-stores.component';
import { DeliveryComponent} from 'src/app/pages/delivery/delivery.component';


export const AdminLayoutRoutes: Routes = [
<<<<<<< Updated upstream
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
=======
   // { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    //{ path: 'icons',          component: IconsComponent },
>>>>>>> Stashed changes
    { path: 'maps',           component: MapsComponent },
    { path: 'afproducts',     component: AfProductComponent },
    { path: 'aforders',       component: AfOrderComponent },
    { path: 'cart',           component: CartComponent },
    { path: 'checkout',       component: CheckoutComponent },
    { path: 'businessAdmin', component: BusinessAdminComponent},
    { path: 'affiliateList', component: AffiliateListComponent },
    { path: 'affiliates', component: AffiliatesComponent},
    { path: 'affiliations', component: AffiliationsComponent},
    { path: 'business', component: BusinessComponent},
    { path: 'businessList', component: BusinessListComponent},
    { path: 'delivererList', component: DelivererListComponent},
    { path: 'deliverers', component: DeliverersComponent},
    { path: 'employeeList', component: EmployeeListComponent},
    { path: 'employees', component: EmployeesComponent},
    { path: 'home', component: ClientHomeComponent},
    { path: 'store/:storeID', component: ClientStoresComponent},
    { path: 'reports', component: ReportsComponent},
    { path: 'delivery', component: DeliveryComponent}
   
];

