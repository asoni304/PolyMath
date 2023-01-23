using System.ComponentModel.DataAnnotations;
using System;

namespace PolyMathAPI.Models.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public DateTime Created { get; set; }
    }
}
