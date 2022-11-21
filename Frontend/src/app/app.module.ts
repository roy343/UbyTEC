import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AfloginComponent } from './pages/aflogin/aflogin.component';
import { AfrequestComponent } from './pages/afrequest/afrequest.component';
import { AfProductComponent } from './pages/af-product/af-product.component';
import { AfOrderComponent } from './pages/af-order/af-order.component';
import { CartComponent } from './pages/cart/cart.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { ClientStoresComponent } from './pages/client-stores/client-stores.component';
import { DeliveryComponent } from './pages/delivery/delivery.component';
import { RegisterComponent } from './pages/register/register.component';


@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
    AfloginComponent,
    AfrequestComponent,
    AfProductComponent,
    AfOrderComponent,
    CartComponent,
    CheckoutComponent,
    ClientStoresComponent,
    DeliveryComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
