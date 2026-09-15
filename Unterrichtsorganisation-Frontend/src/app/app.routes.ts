import { Routes } from '@angular/router';


import { Login } from './_pages/login/login';
import { Overview } from './_pages/overview/overview';



export const routes: Routes = [
    {
        path: '',
        component: Login
    },
    {
        path: 'overview',
        component: Overview
    }
];