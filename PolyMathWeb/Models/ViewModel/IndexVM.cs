using System.Collections.Generic;

namespace PolyMathWeb.Models.ViewModel
{
    public class IndexVM
    {
        public IEnumerable<Genre> GenreList { get; set; }
        public IEnumerable<Article> ArticleList{ get; set; }

    }
}
