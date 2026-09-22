import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {InlineDemo} from './inline-demo/inline-demo'
import {ExternalDemo} from './external-demo/external-demo'

@Component({
  selector: 'app-root',
  imports: [InlineDemo,ExternalDemo,RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('template-demo');
}
