using System;
using System.ComponentModel.DataAnnotations; //validations
namespace DojoSurvVal.Models
{
    public class User
    {
        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string DojoLocation { get; set; }

        [Required]
        public string Language { get; set; }

        [MaxLength(20, ErrorMessage = "Must be less than 20 characters.")]
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}