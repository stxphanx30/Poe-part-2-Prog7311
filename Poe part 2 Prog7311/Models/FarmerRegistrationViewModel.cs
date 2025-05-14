using System.ComponentModel.DataAnnotations;

namespace Poe_part_2_Prog7311.Models
{
    public class FarmerRegistrationViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? IDNumber { get; set; }

        [Required]
        public string? Address { get; set; }
        public IFormFile? PassportPhoto { get; set; }
    }
}