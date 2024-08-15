using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model.Enums;

namespace TrainingMonitor.Domain.Model
{
    public class Training
    {
        public Guid Id { get; set; }
        public DateTime TrainingDateTime { get; set; }
        public byte Intensity { get; set; } // 1-10
        public byte Fatigue { get; set; } // 1-10
        public uint DurationInMinutes { get; set; }
        public double CaloriesSpent { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
