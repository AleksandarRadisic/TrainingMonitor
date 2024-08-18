import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared.module';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [FormsModule, RouterModule, CommonModule, SharedModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  constructor(private authService: AuthService, private snackBar: MatSnackBar, private router: Router) { }

  onSubmit(f: NgForm): void {
    if (f.valid) {
      const registrationData = {
        name: f.value.name,
        surname: f.value.surname,
        email: f.value.email,
        gender: f.value.gender,
        password: f.value.password
      };

      const observer = {
        next: (response: any) => {
          this.snackBar.open('Registration successful', "Dismiss");
          this.router.navigate(['/login'])
        },
        error: (err: any) => {
          this.snackBar.open(err.error, "Dismiss", {verticalPosition: 'top'});
        }
      }

      this.authService.register(registrationData).subscribe(observer);
    }
  }

}
