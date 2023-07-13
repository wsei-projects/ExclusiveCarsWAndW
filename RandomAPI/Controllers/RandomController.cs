using Microsoft.AspNetCore.Mvc;

namespace RandomAPI.Controllers
{
    [ApiController]
    [Route("api/random")]
    public class RandomController : ControllerBase
    {
        private static readonly Random random = new();

        [HttpGet]
        public int GetRandomNumber(int start, int end)
        {
            // dodać walidację, start nie może być większe niż end
            return random.Next(start, end + 1);
        }
    }
}