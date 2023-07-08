using CarsAPI.Models.Dto;
using CarsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarsAPI.Data;

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
        public ActionResult<IEnumerable<PostsDto>> GetPosts()
        {
            var posts = _context.Posts.ToList();
            var postsDto = posts.Select(p => new PostsDto
            {
                Id = p.Id,
                CarId = p.CarId,
                Title = p.Title,
                DateOfCreate = p.DateOfCreate,
                Description = p.Description,
                LongDescription = p.LongDescription
            }).ToList();

            return postsDto;
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public ActionResult<PostsDto> GetPost(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            var postDto = new PostsDto
            {
                Id = post.Id,
                CarId = post.CarId,
                Title = post.Title,
                DateOfCreate = post.DateOfCreate,
                Description = post.Description,
                LongDescription = post.LongDescription
            };

            return postDto;
        }

        // POST: api/posts
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
                LongDescription = postsDto.LongDescription
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            postsDto.CarId = post.CarId;
            postsDto.DateOfCreate = post.DateOfCreate;

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, postsDto);
        }

        // PUT: api/posts/5
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, PostsDto postsDto)
        {
            if (id != postsDto.CarId)
            {
                return BadRequest();
            }

            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            post.CarId = postsDto.CarId;
            post.Title = postsDto.Title;
            post.DateOfCreate = postsDto.DateOfCreate;
            post.Description = postsDto.Description;
            post.LongDescription = postsDto.LongDescription;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/posts/5
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
