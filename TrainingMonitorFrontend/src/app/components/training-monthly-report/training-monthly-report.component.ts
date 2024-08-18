import { Component } from '@angular/core';
import { TrainingService } from '../../service/training.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { DateUtilitiesService } from '../../service/date-utilities.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-training-monthly-report',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './training-monthly-report.component.html',
  styleUrl: './training-monthly-report.component.css'
})
export class TrainingMonthlyReportComponent {
  monthlyReport: any;

  constructor(private trainingService: TrainingService, private snackBar: MatSnackBar, private router: Router, private dateUtils: DateUtilitiesService) {}

  ngOnInit(): void {
    if(!localStorage.getItem("token")){
      this.router.navigate(['/login'])
    }
  }

  onFetchReport(form: any) {
    const { year, month } = form.value;
    const observer = {
      next: (response: any) => {
        this.monthlyReport = response
        console.log(this.monthlyReport)
      },
      error: (err: any) => {
        this.snackBar.open(err.error, "Dismiss", {verticalPosition: 'top'});
      }
    }
    this.trainingService.getReport(year, month).subscribe(observer)
  }
}
