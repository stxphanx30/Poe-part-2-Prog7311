using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Poe_part_2_Prog7311.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? IDNumber { get; set; }
        [Required]
       
        public string? Address { get; set; }

        public string? PassportPhotoPath { get; set; }
    }
}
