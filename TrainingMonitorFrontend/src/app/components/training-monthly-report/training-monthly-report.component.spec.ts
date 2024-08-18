import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingMonthlyReportComponent } from './training-monthly-report.component';

describe('TrainingMonthlyReportComponent', () => {
  let component: TrainingMonthlyReportComponent;
  let fixture: ComponentFixture<TrainingMonthlyReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainingMonthlyReportComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainingMonthlyReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
