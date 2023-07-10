using CarsAPI.Models.Dto;
using CarsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet]
        public ActionResult<IEnumerable<Posts>> GetPosts()
        {
            var posts = _context.Posts.Include("Car").ToList();

            return posts;
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public ActionResult<Posts> GetPost(int id)
        {
            var post = _context.Posts.Include("Car").FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        // Get: api/posts/5/comments
        [HttpGet("{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetPostComments(int id)
        {
            var postcomments = _context.Comment.Include("User").Where(p => p.PostID == id).ToList();

            return postcomments;
        }

        // POST: api/posts
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<PostsDto> CreatePost(PostsDto postsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Posts
            {
                Id = postsDto.Id,
                CarId = postsDto.CarId,
                Title = postsDto.Title,
                DateOfCreate = postsDto.DateOfCreate,
                Description = postsDto.Description,
                LongDescription = postsDto.LongDescription,
                ImageUrl = postsDto.ImageUrl,
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            postsDto.CarId = post.CarId;
            postsDto.DateOfCreate = post.DateOfCreate;

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, postsDto);
        }

        // PUT: api/posts/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, PostsDto postsDto)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            post.CarId = postsDto.CarId;
            post.Title = postsDto.Title;
            post.Description = postsDto.Description;
            post.LongDescription = postsDto.LongDescription;
            post.ImageUrl = postsDto.ImageUrl;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/posts/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
