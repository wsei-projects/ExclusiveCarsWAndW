using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [StringLength(250, ErrorMessage = "Comment cannot be longer than 250 characters.")]
        public string UserComment { get; set; }
        [Required]
        public int PostID { get; set; }
        public Posts Post { get; set; }
    }
}
