using System;
using System.ComponentModel.DataAnnotations;

namespace PolyMathAPI.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public DateTime DateCreated { get; set; }

        
    }
}
