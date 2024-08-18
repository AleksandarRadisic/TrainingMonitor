import { Component } from '@angular/core';
import { convertGenderEnumToString, User } from '../../model/user';
import { AuthService } from '../../service/auth.service';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { convertTrainingTypeToString, Training } from '../../model/training';
import { DateUtilitiesService } from '../../service/date-utilities.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgIf, NgFor, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  user: User | undefined

  constructor(private authService: AuthService, private dateUtils: DateUtilitiesService, private router: Router) {
  }

  ngOnInit(): void {
    if(!localStorage.getItem("token")){
      this.router.navigate(['/login']);
    }
    const observer = {
      next: (user: User) => {
        this.user = user;
        this.user.gender = convertGenderEnumToString(this.user.gender)
        if (this.user.trainings) {
          this.user.trainings.forEach(training => {
            if (training.trainingDateTime !== undefined) {
              training.trainingDateString = this.dateUtils.GetDateString(training.trainingDateTime);
            }
            if (training.trainingType !== undefined) {
              training.trainingType = convertTrainingTypeToString(training.trainingType);
            }
          });
        }
      },
      error: (err: any) => {
        console.error('Failed to load user', err);
      }
    };
    this.authService.loggedUser().subscribe(observer);
  }
}
