import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar'
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {
  constructor(
    private authService: AuthService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {}

  onSubmit(f: NgForm) {
    const loginObserver = {
      next: (x: any) => {
        console.log(x);
        this.snackBar.open("Welcome!", "Dismiss");
        this.router.navigate(['/home']);
      },
      error: (err: any) => {
        console.log(err);
        this.snackBar.open(err.error, "Dismiss", {verticalPosition: 'top'});
      },
    };
    this.authService.login(f.value).subscribe(loginObserver);
  }
}
