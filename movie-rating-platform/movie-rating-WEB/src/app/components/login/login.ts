import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage = '';
  successMessage = '';

  @Output() close = new EventEmitter<boolean>();

  login() {
    this.errorMessage = '';
    this.successMessage = '';

    if (!this.username || !this.password) {
      this.errorMessage = 'Please enter username and password.';
      return;
    }

    // Ovde možeš dodati validaciju demo podataka ako želiš (npr. samo demo/password123 dozvoli)
    if (this.username !== 'demo' || this.password !== 'password123') {
      this.errorMessage = 'Invalid username or password.';
      return;
    }

    // Spremi demo login u localStorage
    localStorage.setItem('username', this.username);
    localStorage.setItem('password', this.password);

    this.successMessage = 'Login successful!';

    setTimeout(() => {
      this.close.emit(true); // emit success
    }, 500);
  }

  cancel() {
    this.close.emit(false); // emit cancel/fail
  }
}
