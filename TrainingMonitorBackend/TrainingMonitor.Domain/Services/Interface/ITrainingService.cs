﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model;

namespace TrainingMonitor.Domain.Services.Interface
{
    public interface ITrainingService
    {
        public void AddTraining(Training training);
        public MonthlyTrainingReport GetUserTrainingReportForMonth(int year, int month, Guid userId);
    }
}
