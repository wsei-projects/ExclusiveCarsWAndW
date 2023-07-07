﻿using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
