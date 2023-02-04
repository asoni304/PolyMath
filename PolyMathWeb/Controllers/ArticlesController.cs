using Microsoft.AspNetCore.Mvc;
using PolyMathWeb.Models;
using PolyMathWeb.Models.ViewModel;
using PolyMathWeb.Repository.IRepository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace PolyMathWeb.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IGenreRepository _genreRepo;
        private readonly IArticleRepository _articleRepo;
        public ArticlesController(IGenreRepository genreRepo, IArticleRepository articleRepo)
        {
            _genreRepo = genreRepo;
            _articleRepo = articleRepo;
        }

        public IActionResult Index()
        {
            return View(new Article() { });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<Genre> genreList = await _genreRepo.GetAllAsync(SD.GenreAPIPath);

            ArticlesVM objVM = new ArticlesVM()
            { 
            GenreList = genreList.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            Article = new Article()
            };

            

            if (id == null)
            {
                //this will be true for create
                return View(objVM);
            }

            //flow will come here for update
            objVM.Article = await _articleRepo.GetAsync(SD.ArticleAPIPath, id.GetValueOrDefault());
            if (objVM.Article == null)
            {
                return NotFound();
            }

            return View(objVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ArticlesVM obj)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    obj.Article.Picture = p1;
                }
                else
                {
                    var objFromDb = await _articleRepo.GetAsync(SD.ArticleAPIPath, obj.Article.Id);
                    obj.Article.Picture = objFromDb.Picture;
                }
                if (obj.Article.Id == 0)
                {
                    await _articleRepo.CreateAsync(SD.ArticleAPIPath, obj.Article);
                }
                else
                {
                    await _articleRepo.UpdateAsync(SD.ArticleAPIPath + obj.Article.Id, obj.Article);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                IEnumerable<Genre> genreList = await _genreRepo.GetAllAsync(SD.GenreAPIPath);

                ArticlesVM objVM = new ArticlesVM()
                {
                    GenreList = genreList.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    Article = obj.Article
                };
                return View(objVM);
            }

        }

        public async Task<IActionResult> GetAllArticles()
        {
            return Json(new { data = await _articleRepo.GetAllAsync(SD.ArticleAPIPath) });

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _articleRepo.DeleteAsync(SD.ArticleAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Succesful" });
            }

            return Json(new { success = false, message = "Delete Not Succesful" });
        }
    }
}
