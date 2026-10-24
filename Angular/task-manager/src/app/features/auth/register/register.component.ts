import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../../core/services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule, RouterLink,
    MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule
  ],
  selector: 'app-register',
  styleUrl: './register.component.scss',
  //templateUrl: './register.component.html',
  template: `
    <div class="auth-wrapper">
      <mat-card class="auth-card">
        <mat-card-header>
          <mat-card-title>🌤️ Create Account</mat-card-title>
          <mat-card-subtitle>Register to use TaskMaster</mat-card-subtitle>
        </mat-card-header>

        <mat-card-content>
          <form [formGroup]="registerForm" (ngSubmit)="onSubmit()">
            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Name</mat-label>
              <input matInput formControlName="name" />
              <mat-error *ngIf="registerForm.get('name')?.hasError('required')">
                Name required
              </mat-error>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Email</mat-label>
              <input matInput formControlName="email" type="email" />
              <mat-error *ngIf="registerForm.get('email')?.hasError('email')">
                Valid email daalo
              </mat-error>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Password</mat-label>
              <input matInput formControlName="password" type="password" />
              <mat-error *ngIf="registerForm.get('password')?.hasError('minlength')">
                Min 6 characters
              </mat-error>
            </mat-form-field>

            <p *ngIf="errorMsg" class="error-msg">{{ errorMsg }}</p>

            <button mat-raised-button color="primary" class="full-width" type="submit">
              REGISTER
            </button>
          </form>

          <p class="switch-link">
            Already registered? <a routerLink="/login">Login</a>
          </p>
        </mat-card-content>
      </mat-card>
    </div>
  `,
  styles: [`
    .auth-wrapper {
      min-height: 100vh;
      display: flex;
      align-items: center;
      justify-content: center;
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    }
    .auth-card { width: 400px; padding: 24px; }
    .full-width { width: 100%; margin-bottom: 8px; }
    .error-msg { color: red; font-size: 14px; margin: 8px 0; }
    .switch-link { text-align: center; margin-top: 16px; }
  `]
})
export class RegisterComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  errorMsg = '';

  registerForm = this.fb.group({
    name: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  onSubmit(): void {
    if (this.registerForm.invalid) return;

    const { name, email, password } = this.registerForm.value;
    const success = this.authService.register(name!, email!, password!);

    if (success) {
      this.router.navigate(['/login']);
    } else {
      this.errorMsg = 'Email already registered';
    }
  }
}
