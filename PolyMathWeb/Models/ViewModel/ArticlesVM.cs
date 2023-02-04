using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace PolyMathWeb.Models.ViewModel
{
    public class ArticlesVM
    {
        public IEnumerable<SelectListItem> GenreList { get; set; }
        public Article Article { get; set; }
    }
}
