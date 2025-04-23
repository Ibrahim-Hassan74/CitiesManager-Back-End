using System.ComponentModel.DataAnnotations;

namespace CitiesManager.Core.Models
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        [Required(ErrorMessage = "City name is required")]
        [StringLength(10, ErrorMessage = "{0} should be between {1} and {2}", MinimumLength = 3)]
        public string? CityName { get; set; }

    }
}
