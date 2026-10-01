export type TicketPriority = 'Low' | 'Medium' | 'High' | 'Critical';
export type TicketStatus = 'Open' | 'InProgress' | 'WaitingForCustomer' | 'Resolved';
export type TicketChannel = 'Email' | 'Phone' | 'Chat' | 'WhatsApp';

export type TicketImpact = 'SingleUser' | 'MultipleUsers' | 'AllUsers';

export type CustomerTier = 'Regular' | 'VIP';

export interface Ticket {
    id: number;
    subject: string;
    customer: string;
    customerEmail: string;
    customerPhone: string;
    channel: TicketChannel;
    category: string;
    tags: string[];
    priority: TicketPriority;
    status: TicketStatus;
    impact: TicketImpact;
    customerTier: CustomerTier;
    assignedTeam: string;
    assignee: string;
    createAt: string;
    lastUpdateAt: string;
    dueAt: string;
}