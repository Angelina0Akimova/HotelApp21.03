using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Hotels 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(20)]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(20)]
        public string City { get; set; } = null!;
        [Required]
        [StringLength(20)]
        public string Country { get; set; } = null!;

        public static readonly List<string> AllowedCountries = new List<string>
        {
            "Россия",
            "США",
            "Франция",
            "Германия",
            "Италия"
        };

    }
}
