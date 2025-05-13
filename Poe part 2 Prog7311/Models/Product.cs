using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poe_part_2_Prog7311.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public string? ImagePath { get; set; }

        // 🔽 Foreign Key vers AppUser
        
        public string? FarmerId { get; set; }

        [ForeignKey("FarmerId")]
        public AppUser? Farmer { get; set; }  // navigation property
    }
}