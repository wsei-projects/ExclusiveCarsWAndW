using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
