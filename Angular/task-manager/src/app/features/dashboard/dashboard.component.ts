import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../core/services/auth.service';
import { WeatherService } from '../../core/services/weather.service';

@Component({
  standalone: true,
  imports: [CommonModule, MatButtonModule],
  selector: 'app-dashboard',
  styleUrl: './dashboard.component.scss',
  //templateUrl: './dashboard.component.html',
  template: `
    <div style="padding: 40px;">
      <h1>🎉 Welcome, {{ authService.currentUser()?.name }}!</h1>
      <p>Ye temporary dashboard hai. Phase 4 me ise proper banayenge.</p>
      <button mat-raised-button color="warn" (click)="authService.logout()">
        Logout
      </button>
    </div>
  `
})
export class DashboardComponent {
  authService = inject(AuthService);

  weatherService = inject(WeatherService);

  ngOnInit() {
    this.weatherService.getWeather('Mumbai').subscribe(data => {
      console.log('Weather:', data);
    });
  }
}

