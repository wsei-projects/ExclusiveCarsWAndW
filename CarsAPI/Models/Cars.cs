using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Model { get; set; }
        [Range(2000, 2023, ErrorMessage = "Year must be between 2000 and 2023")]
        public int Year { get; set; }
        public CarClass Class { get; set; }
        public decimal PricePerDay { get; set; }
    }
    public enum CarClass
    {
        Luxury,
        Economy,
        SUV,
        Sports
    }
}
