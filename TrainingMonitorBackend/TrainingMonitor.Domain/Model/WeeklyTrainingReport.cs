using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitor.Domain.Model
{
    public class WeeklyTrainingReport
    {
        public TimeRange TimeRange { get; set; }
        public uint TotalTrainingTime { get; set; }
        public byte NumberOfTrainings { get; set; }
        public double AverageIntensity { get; set; }
        public double AverageFatigue { get; set; }

        public WeeklyTrainingReport(TimeRange timeRange, IList<Training> trainings)
        {
            TimeRange = timeRange;
            TotalTrainingTime = (uint)trainings.Sum(t => t.DurationInMinutes);
            NumberOfTrainings = (byte)trainings.Count;
            AverageIntensity = NumberOfTrainings > 0 ? trainings.Average(t => t.Intensity) : 0;
            AverageFatigue = NumberOfTrainings > 0 ? trainings.Average(t => t.Fatigue) : 0;
        }
    }
}
