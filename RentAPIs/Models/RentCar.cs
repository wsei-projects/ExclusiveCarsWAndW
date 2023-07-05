namespace RentAPIs.Models
{
    public class RentCar
    {    
            public int Id { get; set; }
            public int CarId { get; set; }
            public Cars Car { get; set; }
            public DateOnly DataWyporzyczenia { get; set; }
            public DateOnly DataZwrotu { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }       
    }
}
