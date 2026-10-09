import { Component, signal } from '@angular/core';
import { Orders } from './orders/orders';

@Component({
  imports: [Orders],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('OrderManagementDashboard');
}
