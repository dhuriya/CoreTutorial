import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  imports: [RouterOutlet,FormsModule],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('two-way-binding-demo');

  customerName: string = 'Deepu';
  orderId: string = 'ORD-10021';
  productName: string = 'Angular Course';
  price: number = 4999;
  quantity: number = 1;
  couponCode: string = '';
  shippingOption: string = 'Standard';
  isPremiumCustomer: boolean = true;
  isPaymentDone: boolean = false;
  stockLeft: number = 3;
  deliveryProgressPercent: number = 35;
  uiMessage: string = '';
  getPaymentLabel(): string{
    return this.isPaymentDone ? 'Paid' : 'Pending';
  }
  getMembershipLabel(): string{
    return this.isPremiumCustomer ? 'Premium' : 'Regular';
  }
  getFinalPayable(): number{
    const total = this.price * this.quantity;
    const discount = this.isPremiumCustomer ? total * 0.2 : 0;

    return total - discount;
  }
  increaseQuantity(): void{
    if(this.quantity < 10){
      this.quantity++;
      this.uiMessage = `Quantity updated to ${this.quantity}.`;
    }
  }
  decreaseQuantity(): void{
    if(this.quantity > 1){
      this.quantity--;
      this.uiMessage = `Quantity updated to ${this.quantity}.`;
    }
  }
  onQuantityChanged(value: number): void{
    const parsed = Number(value);
    if(!Number.isNaN(parsed) && parsed >= 1 && parsed <= 10){
      this.quantity = parsed;
      this.uiMessage = `Quantity set to ${this.quantity}.`;
    }else{
      this.quantity = 1;
      this.uiMessage = `Quantity must be between 1 and 10. Reset to 1.`;
    }
  }
  applyCoupon(): void{
    const code = this.couponCode.trim().toUpperCase();
    if(code===''){
      this.uiMessage = 'Please enter a coupon code.';
      return;
    }
    if(code==='SAVE10'){
      this.uiMessage = 'Coupon applied : SAVE10';
    }else{
      this.uiMessage = `Invalid coupon: ${code}`;
    }
  }
  onShippingChanged(value: string): void{
    this.shippingOption = value;
    this.uiMessage = `Shippping set to ${this.shippingOption}`;
  }
  toggleMembership(): void{
    this.isPremiumCustomer = !this.isPremiumCustomer;
    this.uiMessage = `Membership changed to ${this.getMembershipLabel()}`
  }
  payNow(): void{
    this.isPaymentDone = true;
    this.uiMessage = `Payment received for ${this.orderId}. You can now place the order.`;
    this.deliveryProgressPercent = 60;
  }
  placeOrder(event: Event): void{
    event.preventDefault();
    if(!this.isPaymentDone){
      this.uiMessage = 'Please complete payment before placing the order.';
      return;
    }
    this.uiMessage = `Order placed successfully! Order Id: ${this.orderId}`;
    this.deliveryProgressPercent = 100;
  }
}
