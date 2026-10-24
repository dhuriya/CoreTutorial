import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { AuthService } from '../../../core/services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule
  ],
  standalone: true,
  selector: 'app-login',
  styleUrl: './login.component.scss',
  //templateUrl: './login.component.html',
  template: `
    <div class="auth-wrapper">
      <mat-card class="auth-card">
        <mat-card-header>
          <mat-card-title>🌤️ TaskMaster</mat-card-title>
          <mat-card-subtitle>Login to continue</mat-card-subtitle>
        </mat-card-header>

        <mat-card-content>
          <form [formGroup]="loginForm" (ngSubmit)="onSubmit()">
            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Email</mat-label>
              <input matInput formControlName="email" type="email" />
              <mat-error *ngIf="loginForm.get('email')?.hasError('required')">
                Email required
              </mat-error>
              <mat-error *ngIf="loginForm.get('email')?.hasError('email')">
                Valid email daalo
              </mat-error>
            </mat-form-field>

            <mat-form-field appearance="outline" class="full-width">
              <mat-label>Password</mat-label>
              <input matInput formControlName="password" type="password" />
              <mat-error *ngIf="loginForm.get('password')?.hasError('required')">
                Password required
              </mat-error>
            </mat-form-field>

            <p *ngIf="errorMsg" class="error-msg">{{ errorMsg }}</p>

            <button mat-raised-button color="primary" class="full-width" type="submit">
              LOGIN
            </button>
          </form>

          <p class="switch-link">
            New user? <a routerLink="/register">Register here</a>
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
    .auth-card {
      width: 400px;
      padding: 24px;
    }
    .full-width { width: 100%; margin-bottom: 8px; }
    .error-msg { color: red; font-size: 14px; margin: 8px 0; }
    .switch-link { text-align: center; margin-top: 16px; }
  `]
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  errorMsg = '';

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  });
  onSubmit(): void{
    if(this.loginForm.invalid) return;

    const {email, password} = this.loginForm.value;
    const success = this.authService.login(email!, password!);

    if(success)
    {
      this.router.navigate(['/dashboard']);
    }else{
      this.errorMsg = 'Invalid email or password';
    }
  }
}

// Part	                                                  Kyu
// inject(FormBuilder)	                            Constructor ki jagah modern injection
// fb.group({...})	                                Form ke controls declare — initial value + validators
// Validators.email	                                Angular ka built-in email validator
// loginForm.invalid check	                        Bina valid form submit nahi hone dega
// *ngIf errorMsg	                                  Server-side error user ko dikhao
// routerLink="/register"	                          Navigation — full page reload nahi hoga
// Inline template + styles	                        Chhote components ke liye — ek hi file me sab
// MatCardModule, MatFormFieldModule etc.	          Angular Material ke ready-made UI
