import { Component } from '@angular/core';
import {CommonModule} from '@angular/common'; // Provides common directives and pipes like ngIf, ngFor, ngStyle, Date, currency, etc.
import { Order } from '../models/order.model'; // Import the Order class from the order.ts file

@Component({
  imports: [CommonModule],
  standalone: true,
  selector: 'app-orders',
  styleUrl: './orders.css',
  templateUrl: './orders.html',
})
export class Orders {
  orders: Order ={
    orderId: 'ORD001',
    orderDate: new Date('2023-08-01'),
    status: 'Shipped',
    customer: {
      customerId: 101,
      fullName: 'Alex Johnson',
      email: 'alex.johnson@example.com',
      mobile: '1234567890',
      isPremium: true,
    },
    deliveryAddress: {
      line1: '123 Main St',
      city: 'New York',
      state: 'NY',
      pincode: '10001',
    },
    payment: {
      method: 'Card',
      transactionId: 'TXN123456',
      paidOn: new Date('2023-08-01'),
      paymentStatus: 'Paid',
    },
    items: [
      {
        sku: 'SKU001',
        productName: 'Product A',
        unitPrice: 50,
        qunatity: 2,
        discontPercent: 10,
        gstPercent: 5,
        lineTotal: 95,
      },
      {
        sku: 'SKU002',
        productName: 'Product B',
        unitPrice: 30,
        qunatity: 1,
        discontPercent: 0,
        gstPercent: 5,
        lineTotal: 31.5,
      },
    ],
    totals: {
      subTotalTaxable: 125,
      totalGst: 6.25,
      grandTotal: 131.25,
    }
  };
  getTotalItems(order: Order): number {
    let total = 0;
    for (const item of order.items) {
      total += item.qunatity;
    }
    return total;
  }
  getStatusBadgeClass(status: Order['status']): string {
    switch (status) {
      case 'Delivered':
        return 'badge-success';
      case 'Shipped':
        return 'badge-primary';
      case 'Packed':
        return 'bg-warning text-dark';
      case 'Placed':
        return 'badge-info text-dark';
      case 'Cancelled':
        return 'badge-danger';
      default:
        return 'badge-secondary';
    }
  }
  getPaymentStatusBadgeClass(paymentStatus: Order['payment']['paymentStatus']): string {
    switch (paymentStatus) {
      case 'Paid':
        return 'badge-success';
      case 'Pending':
        return 'badge-warning text-dark';
      case 'Failed':
        return 'badge-danger';
      default:
        return 'badge-secondary';
    }
  }
}
