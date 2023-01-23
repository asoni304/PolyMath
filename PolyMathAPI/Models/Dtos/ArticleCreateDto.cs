using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PolyMathAPI.Models.Dtos
{
    public class ArticleCreateDto
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public byte[] Picture { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int GenreId { get; set; }

       
    }
}
