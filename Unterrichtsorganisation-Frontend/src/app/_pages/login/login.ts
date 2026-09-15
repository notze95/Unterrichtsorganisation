import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../_services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  username: string = '';
  password: string = '';

  constructor(
    private authService: AuthService
  ) { }
  login(): void {

    this.authService
      .login(this.username, this.password)
      .subscribe({

        next: (response) => {
          console.log('Login erfolgreich');
          console.log(response);
        },

        error: (error) => {
          console.error('Login fehlgeschlagen');
          console.error(error);
        }
      });

  }
}