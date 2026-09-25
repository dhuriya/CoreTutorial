import { Component} from '@angular/core';
import { StoreContainer } from './store/store-container/store-container';

@Component({
  imports: [StoreContainer],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  
}
