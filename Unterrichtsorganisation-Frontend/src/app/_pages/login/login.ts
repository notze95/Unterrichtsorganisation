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

          // Hier könntest du später auf die Overview navigieren
          // this.router.navigate(['/overview']);
        },

        error: (error) => {
          console.error('Login fehlgeschlagen');
          console.error(error);
        }
      });
  }
}

// in andere Komponente einfügen wenn api call vorhanden da token immer mitgesendet werden muss
// constructor(private authService: AuthService) {}

// ngOnInit(): void {
//   const token = this.authService.getToken();

//   console.log(token);
// }