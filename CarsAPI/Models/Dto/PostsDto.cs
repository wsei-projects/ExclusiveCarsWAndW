using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models.Dto
{
    public class PostsDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }
}
