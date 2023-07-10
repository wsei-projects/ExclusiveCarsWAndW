using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CarsAPI.Models
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfCreate { get; set; } = DateTime.Now;
        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string Description { get; set; }
        public string LongDescription { get; set; }

        public string ImageUrl { get; set; }
    }
}
