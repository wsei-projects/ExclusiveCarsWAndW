using CarsAPI.Data;
using CarsAPI.Models;
using CarsAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cars
        [HttpGet]
        public ActionResult<IEnumerable<CarDto>> GetCars()
        {
            var cars = _context.Cars.ToList();
            var carsDto = cars.Select(c => new CarDto
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                Year = c.Year,
                ClassId = c.ClassId,
                Description = c.Description
            }).ToList();

            return carsDto;
        }

        // GET: api/cars/5
        [HttpGet("{id}")]
        public ActionResult<CarDto> GetCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carDto = new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                ClassId = car.ClassId,
                Description = car.Description
            };

            return carDto;
        }

        // POST: api/cars
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<CarDto> CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = new Car
            {
                Brand = carDto.Brand,
                Model = carDto.Model,
                Year = carDto.Year,
                ClassId = carDto.ClassId,
                Description = carDto.Description
            };

            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = car.Id;

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, carDto);
        }

        // PUT: api/cars/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, CarDto carDto)
        {
            if (id != carDto.Id)
            {
                return BadRequest();
            }

            var car = _context.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.Brand = carDto.Brand;
            car.Model = carDto.Model;
            car.Year = carDto.Year;
            car.ClassId = carDto.ClassId;
            car.Description = carDto.Description;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/cars/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
