using System.ComponentModel.DataAnnotations;
using System;

namespace PolyMathAPI.Models.Dtos
{
    public class ArticleDto
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

        public GenreDto Genre { get; set; }

    }
}
