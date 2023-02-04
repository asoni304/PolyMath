using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PolyMathWeb.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public byte[] Picture { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int GenreId { get; set; }

        public DateTime DateCreated { get; set; }

        public Genre Genre { get; set; }
    }
}
