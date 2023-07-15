namespace CarsAPI.Models.Dto
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
    }
}