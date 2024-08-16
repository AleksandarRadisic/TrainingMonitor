using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitor.Domain.Model
{
    public class MonthlyTrainingReport
    {
        public IList<WeeklyTrainingReport> WeeklyTrainingReports { get; set; }
        public TimeRange TimeRange { get; set; }

        public MonthlyTrainingReport(IList<Training> trainings, TimeRange timeRange)
        {
            TimeRange = timeRange;
            WeeklyTrainingReports = new List<WeeklyTrainingReport>();

            DateTime start = TimeRange.Start;
            DateTime end = TimeRange.End;

            while (start <= end)
            {
                DateTime weekEnd = start.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (weekEnd > end)
                {
                    weekEnd = end;
                }
                TimeRange weeklyTimeRange = new TimeRange(start, weekEnd);
                var weeklyTrainings = trainings
                    .Where(t => t.TrainingDateTime >= weeklyTimeRange.Start && t.TrainingDateTime <= weeklyTimeRange.End)
                    .ToList();
                WeeklyTrainingReports.Add(new WeeklyTrainingReport(weeklyTimeRange, weeklyTrainings));
                start = weekEnd.AddSeconds(1);
            }
        }
    }
}
