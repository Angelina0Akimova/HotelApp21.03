using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Hotels 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Country { get; set; } = null!;
        [Required]
        [StringLength(50)]
    }
}
