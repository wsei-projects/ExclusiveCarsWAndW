using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Car
    {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Brand { get; set; }
            public string Model { get; set; }
            [Range(2000, 2023, ErrorMessage = "Year must be between 2000 and 2023")]
            public int Year { get; set; }
            public int ClassId { get; set; }
            public CarClass Class { get; set; }
            public decimal PricePerDay { get; set; }
            public string ImageUrl { get; set; }
            public string Description { get; set; } 
    }
}
