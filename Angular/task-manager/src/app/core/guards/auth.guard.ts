import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import tr from '@angular/common/locales/tr';

//--------------------------------------------------------------------------------------------------
//Kyu? — Ye function route pe lagta hai. Agar user logged-in nahi hai, /dashboard access nahi kar
//--------------------------------------------------------------------------------------------------
export const authGuard: CanActivateFn = () => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if(authService.isLoggenIn()){
    return true;
  }
  router.navigate(['/login']);
  return false;
}
