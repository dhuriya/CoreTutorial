import { Component } from '@angular/core';
import { NgClass, NgStyle } from '@angular/common';
import { Ticket, TicketPriority, TicketStatus } from '../models/tickets.model';

@Component({
  imports: [NgClass, NgStyle],
  selector: 'app-tickets-board',
  standalone: true,
  styleUrl: './tickets-board.css',
  templateUrl: './tickets-board.html',
})
export class TicketsBoard {
  searchText ='';
  selectedStatus: TicketStatus | 'All' = 'All';
  selectedPriority: TicketPriority | 'All' = 'All';
  statusOptions: Array<TicketStatus | string>=
  [
    'All','Open', 'InProgress','WaitingForCustomer','Resolved'
  ];
  priorityOptions: Array<TicketPriority | string> = 
  [
    'All', 'Low', 'Medium', 'High', 'Critical'
  ];
  pageSizeOptions = [5,10,15,20];
  pageSize = 5;
  currentPage =1;
  selectedTicket: Ticket | null = null;

  tickets: Ticket[] = [
    { id: 901, subject: 'Payment deducted but order not created', customerPhone:'1234567890', customer: 'Ravi Kumar', customerEmail: 'ravi.kumar@gmail.com', channel: 'WhatsApp', category: 'Payments', tags: ['PaymentFailed', 'Deduction', 'OrderNotCreated'], priority: 'Critical', status: 'Open', impact: 'MultipleUsers', customerTier: 'VIP', assignedTeam: 'Billing', assignee: 'Anita', createAt: '2026-01-28T09:15:00', lastUpdateAt: '2026-01-28T12:30:00', dueAt: '2026-01-28T12:15:00' },
    { id: 902, subject: 'Refund not received (7 days) for UPI transaction', customerPhone:'1234567890', customer: 'Priya Singh', customerEmail: 'priya.singh@gmail.com', channel: 'Email', category: 'Refunds', tags: ['Refund', 'Delay'], priority: 'High', status: 'InProgress', impact: 'SingleUser', customerTier: 'Regular', assignedTeam: 'Billing', assignee: 'Suman', createAt: '2026-01-28T10:05:00', lastUpdateAt: '2026-01-28T11:45:00', dueAt: '2026-01-28T16:05:00' },
    { id: 903, subject: 'Unable to login - OTP not coming on registered mobile', customerPhone:'1234567890', customer: 'John Paul', customerEmail: 'john.paul@gmail.com', channel: 'Chat', category: 'Login', tags: ['OTP', 'LoginIssue'], priority: 'High', status: 'WaitingForCustomer', impact: 'SingleUser', customerTier: 'Regular', assignedTeam: 'Tech', assignee: 'Kiran', createAt: '2026-01-28T10:35:00', lastUpdateAt: '2026-01-28T12:10:00', dueAt: '2026-01-28T14:35:00' },
    { id: 904, subject: 'Change delivery address for order placed today', customerPhone:'1234567890', customer: 'Nandini Mishra', customerEmail: 'nandini.mishra@gmail.com', channel: 'Phone', category: 'Delivery', tags: ['AddressChange'], priority: 'Medium', status: 'Open', impact: 'SingleUser', customerTier: 'VIP', assignedTeam: 'Operations', assignee: 'Deepak', createAt: '2026-01-28T11:10:00', lastUpdateAt: '2026-01-28T11:20:00', dueAt: '2026-01-28T18:10:00' },
    { id: 905, subject: 'Invoice download issue on order history page', customerPhone:'1234567890', customer: 'Amit Sharma', customerEmail: 'amit.sharma@gmail.com', channel: 'Email', category: 'Invoices', tags: ['InvoiceDownload'], priority: 'Low', status: 'Resolved', impact: 'SingleUser', customerTier: 'Regular', assignedTeam: 'Tech', assignee: 'Ritika', createAt: '2026-01-28T08:40:00', lastUpdateAt: '2026-01-28T09:05:00', dueAt: '2026-01-28T20:40:00' },
    { id: 906, subject: 'Double charged for subscription renewal - need reversal', customerPhone:'1234567890', customer: 'Suresh Nayak', customerEmail: 'suresh.nayak@gmail.com', channel: 'Email', category: 'Payments', tags: ['Subscription', 'DoubleCharge'], priority: 'Critical', status: 'InProgress', impact: 'MultipleUsers', customerTier: 'VIP', assignedTeam: 'Billing', assignee: 'Anita', createAt: '2026-01-28T09:50:00', lastUpdateAt: '2026-01-28T12:40:00', dueAt: '2026-01-28T13:20:00' },
    { id: 907, subject: 'Order stuck in processing for 3 hours', customerPhone:'1234567890', customer: 'Meera Das', customerEmail: 'meera.das@gmail.com', channel: 'Chat', category: 'Orders', tags: ['Processing', 'Delay'], priority: 'High', status: 'Open', impact: 'SingleUser', customerTier: 'Regular', assignedTeam: 'Operations', assignee: 'Deepak', createAt: '2026-01-28T10:20:00', lastUpdateAt: '2026-01-28T12:05:00', dueAt: '2026-01-28T15:20:00' },
    { id: 908, subject: 'App crash on checkout screen (Android 14)', customerPhone:'1234567890', customer: 'Rahul Verma', customerEmail: 'rahul.verma@gmail.com', channel: 'WhatsApp', category: 'Technical', tags: ['Crash', 'Checkout'], priority: 'High', status: 'InProgress', impact: 'MultipleUsers', customerTier: 'Regular', assignedTeam: 'Tech', assignee: 'Kiran', createAt: '2026-01-28T09:05:00', lastUpdateAt: '2026-01-28T12:15:00', dueAt: '2026-01-28T13:05:00' },
    { id: 909, subject: 'OTP delayed - arrives after 2 minutes', customerPhone:'1234567890', customer: 'Sweta Patra', customerEmail: 'sweta.patra@gmail.com', channel: 'Phone', category: 'Login', tags: ['OTP', 'Delay'], priority: 'Medium', status: 'WaitingForCustomer', impact: 'SingleUser', customerTier: 'Regular', assignedTeam: 'Tech', assignee: 'Ritika', createAt: '2026-01-28T11:35:00', lastUpdateAt: '2026-01-28T12:25:00', dueAt: '2026-01-28T17:35:00' },
    { id: 910, subject: 'Need cancellation and refund for prepaid order', customerPhone:'1234567890', customer: 'Kunal Jain', customerEmail: 'kunal.jain@gmail.com', channel: 'Email', category: 'Refunds', tags: ['Cancel', 'Refund'], priority: 'High', status: 'Open', impact: 'SingleUser', customerTier: 'VIP', assignedTeam: 'Billing', assignee: 'Suman', createAt: '2026-01-28T11:00:00', lastUpdateAt: '2026-01-28T12:35:00', dueAt: '2026-01-28T16:00:00' }
  ];
  onSearchChange(value: string){
    this.searchText = value ?? ' ';
    this.currentPage = 1;
  }
  setStatus(value: TicketStatus | 'All'){
    this.selectedStatus = value;
    this.currentPage = 1;
  }
  setPriority(value: TicketPriority | 'All'){
    this.selectedPriority = value;
    this.currentPage = 1;
  }

  clearFilters(){
    this.searchText = '';
    this.selectedStatus = 'All';
    this.selectedPriority = 'All';
    this.pageSize = 5;
    this.currentPage = 1;
  }
  onPageSizeChange(value: number){
    this.pageSize = value;
    this.currentPage = 1;
  }
  openTicketModal(ticket: Ticket){
    this.selectedTicket = ticket;
  }
  closeTicketModal(){
    this.selectedTicket = null;
  }
  get filteredTickets(): Ticket[]{
    const text = this.searchText.trim().toLowerCase();
    return this.tickets.filter(t => {
      const matchesText = !text || String(t.id).includes(text) || 
      t.subject.toLowerCase().includes(text) || 
      t.customer.toLowerCase().includes(text) ||
      t.customerEmail.toLowerCase().includes(text);

      const matchesStatus = this.selectedStatus === 'All' || t.status === this.selectedStatus;
      const matchesPriority = this.selectedPriority === 'All' || t.priority === this.selectedPriority;

      return matchesText && matchesStatus && matchesPriority;
    })
  }
  get totalItems(): number{
    return this.filteredTickets.length;
  }
  get totalPages(): number{
    return Math.max(1, Math.ceil(this.totalItems / this.pageSize));
  }
  get pagedTickets(): Ticket[]{
    const start = (this.currentPage - 1) * this.pageSize;
    return this.filteredTickets.slice(start + this.pageSize);
  }
  goToFirst() {this.currentPage = 1;}
  goToLast() {this.currentPage = this.totalPages;}
  goToPrevious() {if(this.currentPage > 1) this.currentPage --;}
  goToNext() { if (this.currentPage < this.totalPages) this.currentPage++;}

  private now(): number {
    return new Date('2026-01-28T13:00:00').getTime();
  }
  minutesLeft(t: Ticket) : number {
    const due = new Date(t.dueAt).getDate();
    return Math.round((due - this.now()) / 60000);
  }
  isBreached(t: Ticket): boolean {
    return this.minutesLeft(t) <= 0 && t.status !== 'Resolved';
  }
  isResolved(t: Ticket): boolean{
    return t.status === 'Resolved';
  }
  slaPercent(t: Ticket): number {
    const totalMinutes = 240;
    const used = totalMinutes - this.minutesLeft(t);
    const pct = Math.round((used / totalMinutes) * 100);
    return Math.max(0, Math.min(100,pct));
  }
  priorityBadgeClass(p: TicketPriority): string {
    switch(p){
      case 'Critical' : return 'text-danger';
      case 'High' : return 'text-bg-warning text-dark';
      case 'Medium' : return 'text-bg-ingo text-dark';
      case 'Low' : return 'text-bg-secondary';
      default: return 'text-bg-dark';
    }
  }
  statusBadgeClass(status: TicketStatus): string {
    switch(status){
      case 'Open': return 'text-bg-primary';
      case 'InProgress': return 'text-bg-warning text-dark';
      case 'WaitingForCustomer': return 'text-bg-info text-dark';
      case 'Resolved': return 'text-bg-success';
      default : return 'text-bg-secondry';
    }
  }
  progressBarClass(t: Ticket) : string {
    if(this.isResolved(t)) return 'Success';
    if(this.isBreached(t)) return 'danger';
    const pct = this.slaPercent(t);
    return pct >= 80? 'bg-warning' : 'primary';
  }
  formatDate(iso: string): string{
    return new Date(iso).toLocaleDateString();
  }
}
