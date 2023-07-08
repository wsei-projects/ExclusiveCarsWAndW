using CarsAPI.Data;
using CarsAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarClassesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarClassesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/carclasses
        [HttpGet]
        public ActionResult<IEnumerable<CarClassDto>> GetCarClasses()
        {
            var carClasses = _context.CarClasses.ToList();
            var carClassesDto = carClasses.Select(c => new CarClassDto
            {
                Id= c.Id,
                Name = c.Name
            }).ToList();

            return carClassesDto;
        }

        // GET: api/carclasses/5
        [HttpGet("{id}")]
        public ActionResult<CarClassDto> GetCarClass(int id)
        {
            var carClass = _context.CarClasses.FirstOrDefault(c => c.Id == id);

            if (carClass == null)
            {
                return NotFound();
            }

            var carClassDto = new CarClassDto
            {
                Id = carClass.Id,
                Name = carClass.Name
            };

            return carClassDto;
        }
    }
}
