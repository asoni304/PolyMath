using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyMathWeb.Models;
using PolyMathWeb.Models.ViewModel;
using PolyMathWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PolyMathWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenreRepository _genreRepo;
        private readonly IArticleRepository _articleRepo;





        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepo,IGenreRepository genreRepository)
        {
            _logger = logger;
            _articleRepo = articleRepo;
            _genreRepo = genreRepository;


        }

        public async Task<IActionResult> Index()
        {
            IndexVM ListOfGenresAndArticles = new IndexVM()
            {
                GenreList = await _genreRepo.GetAllAsync(SD.GenreAPIPath),
                ArticleList = await _articleRepo.GetAllAsync(SD.ArticleAPIPath)
            };
            return View(ListOfGenresAndArticles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
