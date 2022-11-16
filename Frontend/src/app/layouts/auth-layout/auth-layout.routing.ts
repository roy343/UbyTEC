import { Routes } from '@angular/router';

import { LoginComponent } from '../../pages/login/login.component';
import { RegisterComponent } from '../../pages/register/register.component';
import { AfloginComponent } from '../../pages/aflogin/aflogin.component';
import { AfrequestComponent } from '../../pages/afrequest/afrequest.component';

export const AuthLayoutRoutes: Routes = [
    { path: 'login',          component: LoginComponent },
    { path: 'register',       component: RegisterComponent },
    { path: 'aflogin',       component: AfloginComponent },
    { path: 'afrequest',       component: AfrequestComponent }
];
