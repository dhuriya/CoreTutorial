import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentList } from './student-list/student-list';
// import { StudentCount } from './student-count/student-count';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StudentList
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('student-dashboard');
}