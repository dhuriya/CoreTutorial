import { Component, EventEmitter, Input, Output, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  imports: [RouterLink, RouterLinkActive],
  selector: 'app-student-component-sidebar',
  styleUrl: './student-component-sidebar.css',
  templateUrl: './student-component-sidebar.html',
})
export class StudentComponentSidebar {
  @Input() mobileOpen = false;
  @Output() readonly navigate = new EventEmitter<void>();
  protected readonly activeSection = signal('');

  protected selectSection(section: string): void {
    this.activeSection.set(section);
  }
}
