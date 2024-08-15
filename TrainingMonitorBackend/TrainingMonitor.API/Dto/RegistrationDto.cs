using System.ComponentModel.DataAnnotations;
using TrainingMonitor.Domain.Model.Enums;

namespace TrainingMonitor.API.Dto
{
    public class RegistrationDto
    {
        [MinLength(5, ErrorMessage = "Password must have at least 5 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
    }
}
