using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolyMathAPI.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public byte[] Picture { get; set; }

        [Required]
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]

        public Genre Genre { get; set; }
    }
}
