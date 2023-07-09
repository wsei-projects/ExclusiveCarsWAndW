using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserComment { get; set; }
        public int PostID { get; set; }
    }
}
