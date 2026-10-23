import {Injectable, signal} from '@angular/core';
import {Router} from '@angular/router';
import {User} from '../models/user.model';
import { SIGNAL } from '@angular/core/primitives/signals';
import { email } from '@angular/forms/signals';
import { I } from '@angular/cdk/keycodes';
import { JsonPipe } from '@angular/common';
import tr from '@angular/common/locales/tr';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private readonly USERS_KEY = 'tm_users';
  private readonly CURRENT_USER_KEY = 'tm_current_user';

  //Signal - reactive state, jab bhi change hoga UI auto-update
  currentUser = signal<User | null>(this.getCurrentUser());

  constructor(private router: Router){}
  // REGISTER
  register(name: string, email: string, password: string): boolean{
    const users = this.getAllUsers();

    //Check duplicate email
    if(users.find(u => u.email == email)){
      return false;
    }
    const newUser: User = {
      id: crypto.randomUUID(),
      name,
      email,
      password
    };
    users.push(newUser);
    localStorage.setItem(this.USERS_KEY, JSON.stringify(users));
    return true;
  }
   /// LOGIN
  login(email:string, password: string): boolean{
    const users = this.getAllUsers();
    const user = users.find(u => u.email === email && u.password == password);

    if(!user) return false;
    localStorage.setItem(this.CURRENT_USER_KEY, JSON.stringify(user));
    this.currentUser.set(user);
    return true;
  }
  // ---------------------- LOGOUT ---------------------------
  logout():void{
    localStorage.removeItem(this.CURRENT_USER_KEY);
    this.currentUser.set(null);
    this.router.navigate(['/login']);
  }
  //-------------------- HELPER -----------------------------
  isLoggenIn(): boolean{
    return !!localStorage.getItem(this.CURRENT_USER_KEY);
  }
  private getAllUsers(): User[] {
    const row = localStorage.getItem(this.USERS_KEY);
    return row ? JSON.parse(row) : [];
  }
  private getCurrentUser(): User | null {
    const row = localStorage.getItem(this.CURRENT_USER_KEY)
    return row ? JSON.parse(row) : null;
  }

}
