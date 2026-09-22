import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('interpolation-demo');
  customerName: string ='Deepu Dhuriya';
  orderId: string = 'ORD-10021';
  productName: string = 'Angular Course - Full Stack Bundle';
  price: number = 4999;
  quantity: number = 1;
  isPremiumCustomer: boolean = true;
  isPaymentDone: boolean = false;
  getFinalAmount(): number {
    const total = this.price * this.quantity;
    const discount = this.isPremiumCustomer? total * 0.2 : 0;
    return total - discount;
  }
  getOrderStatusMessage(): string {
    return this.isPaymentDone ? `Payment received for order ${this.orderId}. Your order is confirmed`:`Payment pending for order ${this.orderId}. Please complete payment`;
  }
}
