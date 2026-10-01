import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TicketsBoard } from './tickets-board/tickets-board';

@Component({
  imports: [RouterOutlet, TicketsBoard],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('supports-tickets');
}
