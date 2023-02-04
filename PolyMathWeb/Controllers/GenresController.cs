using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyMathWeb.Models;
using PolyMathWeb.Repository.IRepository;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace PolyMathWeb.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepo;
        public GenresController(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public IActionResult Index()
        {
            return View(new Genre() { });
        }

        public async Task<IActionResult> GetAllGenres()
        {
            return Json(new { data = await _genreRepo.GetAllAsync(SD.GenreAPIPath)});

        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Genre obj = new Genre();

            if (id == null)
            {
                //this will be true for create
                return View(obj);
            }

            //flow will come here for update
            obj = await _genreRepo.GetAsync(SD.GenreAPIPath, id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Upsert(Genre obj)
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
                    obj.Picture = p1;
                }
                else
                {
                    var objFromDb = await _genreRepo.GetAsync(SD.GenreAPIPath, obj.Id);
                    obj.Picture = objFromDb.Picture;
                }
                if (obj.Id == 0)
                {
                    await _genreRepo.CreateAsync(SD.GenreAPIPath, obj);
                }
                else
                {
                    await _genreRepo.UpdateAsync(SD.GenreAPIPath + obj.Id, obj);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obj);
            }

        }


        [HttpDelete]
       
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _genreRepo.DeleteAsync(SD.GenreAPIPath, id); 
            if (status)
            {
                return Json(new { success = true, message = "Delete Succesful" });
            }

            return Json(new { success = false, message = "Delete Not Succesful" });
        }
    }
}
