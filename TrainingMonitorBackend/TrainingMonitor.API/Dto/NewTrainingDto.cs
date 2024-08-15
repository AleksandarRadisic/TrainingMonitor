using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.Model.Enums;

namespace TrainingMonitor.API.Dto
{
    public class NewTrainingDto
    {
        public DateTime TrainingDateTime { get; set; }
        public byte Intensity { get; set; } // 1-10
        public byte Fatigue { get; set; } // 1-10
        public uint DurationInMinutes { get; set; }
        public double CaloriesSpent { get; set; }
        public TrainingType TrainingType { get; set; }
    }
}
