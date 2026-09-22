import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('class-binding-demo');
  customerName:string = 'Deepu Dhuriya';
  orderId:string = 'ORD-10021';
  productName: string = 'Angular Couse - Full Stack Bundle';
  isPaymentDone: boolean = false;
  isPremimuCustomer:boolean = true;
  stockLeft: number = 3;

  isHighPriorityOrder: boolean = true;
  getPaymentLabel(): string {
    return this.isPaymentDone ? 'Pain' : 'Pending';
  }
  getMembershipLabel(): string {
    return this.isPremimuCustomer ? 'Premium': 'Regular';
  }
}
