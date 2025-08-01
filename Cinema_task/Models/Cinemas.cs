﻿using System.ComponentModel.DataAnnotations;

namespace Cinema_task.Models
{
    public class Cinemas
    {
        [Key]
        public int CinemaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? CinemaLogo { get; set; }
        public string? Address { get; set; }

        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
    }
}
