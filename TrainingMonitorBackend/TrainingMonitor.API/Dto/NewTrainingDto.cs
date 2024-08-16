using System.ComponentModel.DataAnnotations;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.Model.Enums;

namespace TrainingMonitor.API.Dto
{
    public class NewTrainingDto
    {
        [Required(ErrorMessage = "Training Date and time is required")]
        public DateTime TrainingDateTime { get; set; }

        [Required(ErrorMessage = "Intensity is required")]
        [Range(1, 10, ErrorMessage = "Intensity must be between 1 and 10.")]
        public byte Intensity { get; set; } // 1-10

        [Required(ErrorMessage = "Fatigue is required")]
        [Range(1, 10, ErrorMessage = "Fatigue must be between 1 and 10.")]
        public byte Fatigue { get; set; } // 1-10

        [Required(ErrorMessage = "Training duration is required")]
        public uint DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Calories spent is required")]
        public double CaloriesSpent { get; set; }

        [Required(ErrorMessage = "Training type is required")]
        public TrainingType TrainingType { get; set; }
    }
}
