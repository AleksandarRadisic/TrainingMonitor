using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrainingMonitor.Domain.Model.Enums;


namespace TrainingMonitor.Domain.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Training> Trainings { get; set; }
    }
}
