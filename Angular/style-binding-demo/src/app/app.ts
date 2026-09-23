import tr from '@angular/common/locales/tr';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { max } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('style-binding-demo');
  customerName: string ='Deepu Dhuriya';
  orderId: string = 'ORD-10021';
  productName: string = 'Angular Course';
  isPaymentDone: boolean = false;
  isPremiumCustomer: boolean = true;
  isHighPriorityOrder:boolean = true;
  stockLeft: number = 3;
  deliveryProgresssPercent: number = 65;
  invoiceUrl: string = 'https://example.com/invoice/ORD-10021.pdf';
  isLowStock(): boolean {
    return this.stockLeft <= 5;
  }
  getPaymentLable(): string {
    return this.isPaymentDone ? 'Paid' :'Pending';
  }
  getMemberShipLabel(): string {
    return this.isPremiumCustomer ? 'Premium': 'Regular';
  }
  getProgressWidth(): number{
    return Math.max(0, Math.min(this.deliveryProgresssPercent, 100));
  }
  getInvoiceOpacity(): string {
    return this.isPaymentDone ?  '1' : '0.5';
  }
}
