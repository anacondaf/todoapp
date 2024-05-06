import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: 'dashboard',
    loadComponent: () =>
      import('./components/dashboard/dashboard.component').then(
        (m) => m.DashboardComponent
      ),
  },
  {
    path: 'purchase',
    loadComponent: () =>
      import('./components/purchase-order/purchase-order.component').then(
        (m) => m.ContentFillComponent
      ),
  },
];
