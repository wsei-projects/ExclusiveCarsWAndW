using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Brand cannot be longer than 20 characters.")]
        public string Brand { get; set; }
        [StringLength(20, ErrorMessage = "Model cannot be longer than 20 characters.")]
        public string Model { get; set; }
        [Range(2000, 2023, ErrorMessage = "Year must be between 2000 and 2023")]
        public int Year { get; set; }
        public int ClassId { get; set; }
        public CarClass Class { get; set; }
        public string ImageUrl { get; set; }
        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string Description { get; set; }
    }
}
