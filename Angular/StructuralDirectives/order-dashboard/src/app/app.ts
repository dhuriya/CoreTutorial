import { Component, signal } from '@angular/core';
import { OrdersDashboard} from './orders-dashboard/orders-dashboard';

@Component({
  imports: [OrdersDashboard],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  
}
