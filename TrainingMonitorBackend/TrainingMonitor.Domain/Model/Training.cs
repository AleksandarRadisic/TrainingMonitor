using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model.Enums;

namespace TrainingMonitor.Domain.Model
{
    public class Training
    {
        public Guid Id { get; private set; }
        public DateTime TrainingDateTime { get; private set; }
        public byte Intensity { get; private set; } // 1-10
        public byte Fatigue { get; private set; } // 1-10
        public uint DurationInMinutes { get; private set; }
        public double CaloriesSpent { get; private set; }
        public TrainingType TrainingType { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Training(){}
        public Training(TrainingType type, DateTime trainingDateTime, byte intensity, byte fatigue, uint durationInMinutes, double caloriesSpent, Guid userId)
        {
            TrainingType = type;
            TrainingDateTime = trainingDateTime;
            Intensity = intensity;
            Fatigue = fatigue;
            DurationInMinutes = durationInMinutes;
            CaloriesSpent = caloriesSpent;
            UserId = userId;
            validate();
        }
        private void validate()
        {
            if (Intensity is < 1 or > 10)
            {
                throw new ArgumentException("Intensity must be in range 1-10");
            }
            if (Fatigue is < 1 or > 10)
            {
                throw new ArgumentException("Fatigue must be in range 1-10");
            }
        }
    }
}
