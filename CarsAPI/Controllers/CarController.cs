using CarsAPI.Data;
using CarsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CarController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Car> cars = _db.Cars.ToList();
                return cars;
            }
            catch(Exception ex)
            {

            }
            return null;

        }
    }
}
