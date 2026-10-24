import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {
    path: 'login', loadComponent: () =>
      import('./features/auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./features/auth/register/register.component').then(m => m.RegisterComponent)
  },
  {
    path: 'dashboard',
    canActivate: [authGuard],  // 🔒 Protected
    loadComponent: () =>
      import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent)
  },
  { path: '**', redirectTo: '/login' }
];

// Part	                                  Kyu
// redirectTo:                            '/login'	Empty path pe login pe bhejo
// loadComponent	                        Lazy loading — route visit karne pe hi code download hoga (initial bundle chhota)
// canActivate: [authGuard]	              Bina login ke dashboard access nahi
// path: '**'	                            Galat URL pe login pe redirect
