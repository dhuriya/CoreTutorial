import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('event-binding-demo');
  customerName: string = 'Deepu';
  orderId: string = 'ORD-10021';
  productName: string = 'Angular Course';
  price: number =4999;
  quantity: number = 1;
  couponCode: string = '';
  shippingOption: string = 'Standard';
  isPremiumCustomer: boolean = true;
  isPaymentDone: boolean = false;
  stockLeft: number = 3;
  deliveryProgressPercent: number = 35;
  uiMessage: string = '';
  getPaymentLabel(): string {
    return this.isPaymentDone ? 'Pain' : 'Pending';
  }
  getMemberShipLabel(): string {
    return this.isPremiumCustomer ? 'Premium' : 'Regular';
  }
  getFinalPayable(): number {
    const total = this.price * this.quantity;
    const discount = this.isPremiumCustomer ? total * 0.2 : 0;
    return total - discount;
  }
  increeaseQuantity(): void{
    if(this.quantity < 10){
      this.quantity++;
      this.uiMessage = `Quantity updated to ${this.quantity}.`;
    }
  }
  decreaseQuantity(): void{
    if(this.quantity>1){
      this.quantity--;
      this.uiMessage = `Quantity updated to ${this.quantity}.`;
    }
  }
  onQuantityInput(event:Event): void{
    const value = (event.target as HTMLInputElement).value;
    const parsed = Number(value);
    if(!Number.isNaN(parsed) && parsed >=1 && parsed <=10){
      this.quantity = parsed;
      this.uiMessage = `Qunatity set to ${this.quantity}.`;
    }else{
      this.uiMessage = 'Qunatity must be between 1 and 10.'
    }
  }
  onCouponInput(event: Event): void{
    this.couponCode = (event.target as HTMLInputElement).value;
  }
  applyCoupon(): void{
    const code = this.couponCode.trim().toUpperCase();
    if(code ===''){
      this.uiMessage = 'Please enter a coupon code.'
      return;
    }
    if(code ==='SAVE10'){
      this.uiMessage = 'Coupon applied SAVE10';
    }else{
      this.uiMessage = `Invalid coupon: ${code}`;
    }
  }
  onShippingChange(event: Event): void{
    this.shippingOption = (event.target as HTMLSelectElement).value;
    this.uiMessage = `Shipping set to ${this.shippingOption}`;
  }
  payNow(): void{
    this.isPaymentDone = true;
    this.uiMessage = `Payment received for ${this.orderId}. You can now place this order.`;
    this.deliveryProgressPercent = 60;
  }
  placeOrder(event: Event): void{
    event.preventDefault();
    if(!this.isPaymentDone){
      this.uiMessage = 'Please complete payment before placing the order.'
      return;
    }
    this.uiMessage = `Order placed successfully! Order Id ${this.orderId}`;
    this.deliveryProgressPercent = 100;
  }
  toggleMembership(): void{
    this.isPremiumCustomer = !this.isPremiumCustomer;
    this.uiMessage = `Membership changed to: ${this.getMemberShipLabel()}`;
  }
}
