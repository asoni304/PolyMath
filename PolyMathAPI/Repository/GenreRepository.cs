using PolyMathAPI.Data;
using PolyMathAPI.Models;
using PolyMathAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PolyMathAPI.Repository
{
    public class GenreRepository :IGenreRepository
    {
        private readonly ApplicationDbContext _db;

        public GenreRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateGenre(Genre genre)
        {
            _db.Genres.Add(genre);
            return Save();
        }

        public bool DeleteGenre(Genre genre)
        {
            _db.Genres.Remove(genre);
            return Save();
        }

        public bool GenreExists(string genreName)
        {
            bool value = _db.Genres.Any(a => a.Name.ToLower().Trim() == genreName.ToLower().Trim());
            return value;
        }

        public bool GenreExists(int genreId)
        {
            bool value = _db.Genres.Any(a => a.Id == genreId);
            return value;
        }

        public Genre GetGenre(int genreId)
        {
            return _db.Genres.FirstOrDefault(a=>a.Id== genreId);
        }

        public ICollection<Genre> GetGenres()
        {
            return _db.Genres.OrderBy(a => a.Name).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateGenre(Genre genre)
        {
            _db.Genres.Update(genre);
            return Save();
        }
    }
}
