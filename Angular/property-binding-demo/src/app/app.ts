import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('property-binding-demo');
  customerName: string = 'Deepu Dhuriya';
  OrderId: string = 'ORD-10021';
  productName: string = 'Angular Course - Full Stack Bundle';
  price: number = 4999;
  quantity:number = 1;
  isPremiumCustomer : boolean = true;
  isPaymentDone: boolean = false;
  productImageUrl: string = 'https://placehold.co/180x120/png?text=Angular+Course';
  invoiceUrl:string ='https://placehold.co/180x120/png?text=Angular+Course';
  getOrderTooltip(): string {
    return `Order: ${this.OrderId} | Customer: ${this.customerName}`;
  }
  getFinalAmount(): number {
    const total = this.price * this.quantity;
    const discount = this.isPremiumCustomer? total * 0.2:0;
    return total - discount;
  }
  getPaymentLabel(): string{
    return this.isPaymentDone ? 'Payment Successful' : 'Payement pending';
  }
  getStatusColor(): string {
    return this.isPaymentDone ? 'green' : 'crimson';
  }
}
