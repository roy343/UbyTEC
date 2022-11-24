import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeListComponent } from '../../pages/employee-list/employee-list.component';
import { DelivererListComponent } from '../../pages/deliverer-list/deliverer-list.component';
import { AffiliateListComponent } from '../../pages/affiliate-list/affiliate-list.component';
import { AffiliationsComponent } from '../../pages/affiliations/affiliations.component';
import { BusinessListComponent } from '../../pages/business-list/business-list.component';
import { ReportsComponent } from '../../pages/reports/reports.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule
  ],
  declarations: [
    UserProfileComponent,
    TablesComponent,
    //IconsComponent,
    MapsComponent,
    EmployeeListComponent,
    DelivererListComponent,
    AffiliateListComponent,
    AffiliationsComponent,
    BusinessListComponent,
    ReportsComponent
  ]
})

export class AdminLayoutModule {}
