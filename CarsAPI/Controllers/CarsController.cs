using AutoMapper;
using CarsAPI.Data;
using CarsAPI.Models;
using CarsAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CarsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Cars> cars = _db.Cars.ToList();
                _response.Result = _mapper.Map<IEnumerable<CarsDto>>(cars);               
            }
            catch(Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Cars cars = _db.Cars.First(u=>u.Id==id);
                _response.Result = _mapper.Map<Cars>(cars);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CarsDto carDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid car data");
                }

                var car = _mapper.Map<Cars>(carDto);
                _db.Cars.Add(car);
                _db.SaveChanges();

                var createdCarDto = _mapper.Map<CarsDto>(car);
                return CreatedAtAction(nameof(Get), new { id = car.Id }, createdCarDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarsDto carDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid car data");
                }

                var existingCar = _db.Cars.FirstOrDefault(c => c.Id == id);
                if (existingCar == null)
                {
                    return NotFound();
                }

                _mapper.Map(carDto, existingCar);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var car = _db.Cars.FirstOrDefault(c => c.Id == id);
                if (car == null)
                {
                    return NotFound();
                }

                _db.Cars.Remove(car);
                _db.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
