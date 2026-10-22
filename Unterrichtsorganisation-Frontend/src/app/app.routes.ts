import { Routes } from '@angular/router';


import { Login } from './_pages/login/login';
import { Overview } from './_pages/overview/overview';
import { CreateRequest } from './_pages/create-request/create-request';



export const routes: Routes = [
    { path: '', component: Login },
    { path: 'overview', component: Overview },
    { path: 'create-request', component: CreateRequest }
];