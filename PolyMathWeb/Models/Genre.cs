using System.ComponentModel.DataAnnotations;
using System;

namespace PolyMathWeb.Models
{
    public class Genre
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
