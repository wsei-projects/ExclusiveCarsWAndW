using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }   
        public string Model { get; set; }
        public int Year { get; set; }
        public int ClassId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
