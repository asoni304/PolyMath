using PolyMathAPI.Models;
using System.Collections.Generic;

namespace PolyMathAPI.Repository.IRepository
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres(); //get all genres

        Genre GetGenre(int genreId); //get one genre

        bool GenreExists(string name); //if genre exists based on name

        bool GenreExists(int id);  //if genre exists based on id

        bool CreateGenre(Genre genre);

        bool UpdateGenre(Genre genre);
        bool DeleteGenre(Genre genre);

        bool Save();
    }
}
