export interface Address{
    line1: string;
    line2?: string;
    city: string;
    state: string;
    pincode: string
}
export interface Customer{
    customerId: number;
    fullName: string;
    email: string;
    mobile: string;
    isPremium: boolean;
}
export interface PaymentInfo{
    method: 'UPI' | 'Card' | 'NetBaking' |'COD';
    transactionId?: string;
    paidOn?: Date;
    paymentStatus: 'Paid' | 'Pending' | 'Failed';
}
export interface OrderItem{
    sku: string;
    productName: string;
    unitPrice: number;
    qunatity: number;
    discontPercent: number;
    gstPercent: number;
    lineTotal: number;
}
export  interface OrederTotals{
    subTotalTaxable: number;
    totalGst: number;
    grandTotal: number;
}
export interface Order{
    orderId: string;
    orderDate: Date;
    status: 'Placed' | 'Packed' | 'Shipped' | 'Delivered'|'Cancelled';
    customer: Customer;
    deliveryAddress: Address;
    payment: PaymentInfo;
    items: OrderItem[];
    totals: OrederTotals;
}