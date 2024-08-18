import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { TrainingService } from '../../service/training.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-training',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-training.component.html',
  styleUrl: './add-training.component.css'
})
export class AddTrainingComponent {
  trainingTypes = ['Cardio', 'Strength', 'Flexibility', 'Balance'];

  maxDateTime: string | undefined;
  defaultDateTime: string | undefined;

  constructor(private trainingService: TrainingService, private snackBar: MatSnackBar, private router: Router){}

  ngOnInit(): void {
    const now = new Date();
    this.maxDateTime = now.toISOString().slice(0, 16);
    this.defaultDateTime = new Date(now.getTime() - now.getTimezoneOffset() * 60000).toISOString().slice(0, 16);
  }

  onSubmit(form: NgForm) {
      const newTraining = form.value;
      newTraining.trainingDateTime = newTraining.trainingDateTime + "Z";
      console.log(newTraining)
      const observer = {
        next: (response: any) => {
          this.snackBar.open('Training added successfully', "Dismiss");
          this.router.navigate(['/home'])
        },
        error: (err: any) => {
          console.log(err)
          this.snackBar.open(err.error, "Dismiss", {verticalPosition: 'top'});
        }
      }

      this.trainingService.addTraining(newTraining).subscribe(observer);
  }
}
