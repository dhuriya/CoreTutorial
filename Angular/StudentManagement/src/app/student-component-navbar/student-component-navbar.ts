import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-student-component-navbar',
  templateUrl: './student-component-navbar.html',
  styleUrl: './student-component-navbar.css',
})
export class StudentComponentNavbar {
  @Input() mobileMenuOpen = false;
  @Output() readonly mobileMenuToggle = new EventEmitter<void>();
}