import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {StudentComponentSidebar} from './student-component-sidebar/student-component-sidebar'
import { StudentComponentNavbar } from './student-component-navbar/student-component-navbar';

@Component({
  imports: [RouterOutlet, StudentComponentSidebar, StudentComponentNavbar],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly mobileNavOpen = signal(false);

  protected toggleMobileNav(): void {
    this.mobileNavOpen.update((isOpen) => !isOpen);
  }

  protected closeMobileNav(): void {
    this.mobileNavOpen.set(false);
  }
}
