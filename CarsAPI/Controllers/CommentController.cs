using CarsAPI.Models.Dto;
using CarsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using CarsAPI.Data;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/comments
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> GetComments()
        {
            var comments = _context.Comment.ToList();
            var commentsDto = comments.Select(c => new CommentDto
            {
                Id = c.Id,
                UserId = c.UserId,
                UserComment = c.UserComment,
                PostID = c.PostID // Dodane pole PostId
            }).ToList();

            return commentsDto;
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        public ActionResult<CommentDto> GetComment(int id)
        {
            var comment = _context.Comment.FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            var commentDto = new CommentDto
            {   
                Id = comment.Id,
                UserId = comment.UserId,
                UserComment = comment.UserComment,
                PostID = comment.PostID // Dodane pole PostId
            };

            return commentDto;
        }

        // POST: api/comments
        [HttpPost]
        public ActionResult<CommentDto> CreateComment(CommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = new Comment
            {   
                Id = commentDto.Id,
                UserId = commentDto.UserId,
                UserComment = commentDto.UserComment,
                PostID = commentDto.PostID // Dodane pole PostId
            };

            _context.Comment.Add(comment);
            _context.SaveChanges();

            commentDto.UserId = comment.UserId;

            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, commentDto);
        }

        // PUT: api/comments/5
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, CommentDto commentDto)
        {
            if (id != commentDto.UserId)
            {
                return BadRequest();
            }

            var comment = _context.Comment.FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            comment.UserId = commentDto.UserId;
            comment.UserComment = commentDto.UserComment;
            comment.PostID = commentDto.PostID; // Dodane pole PostId

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/comments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comment.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
