using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PolyMathAPI.Data;
using PolyMathAPI.Models;
using PolyMathAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace PolyMathAPI.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticleRepository(ApplicationDbContext db) 
        {
        _db= db;
        }

        public bool ArticleExists(string title)
        {
            bool value = _db.Articles.Any(a => a.Title.ToLower().Trim() == title.ToLower().Trim());
            return value;
        }

        public bool ArticleExists(int id)
        {
            bool value = _db.Articles.Any(a=> a.Id==id);
            return value;
        }

        public bool CreateArticle(Article article)
        {
           _db.Articles.Add(article);
            return Save();
        }

        public bool DeleteArticle(Article article)
        {
            _db.Articles.Remove(article);
            return Save();
        }

        public ICollection<Article> GetAllArticlesInGenre(int genreId)
        {
            return _db.Articles.Include(c => c.Genre).Where(c => c.GenreId == genreId).ToList();
        }

        public Article GetArticleInGenre(int articleId)
        {
            return _db.Articles.Include(c=>c.Genre).FirstOrDefault(a=>a.Id==articleId);
        }

        public ICollection<Article> GetAllArticles()
        {   
            return _db.Articles.Include(c=>c.Genre).OrderBy(a=>a.Id).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateArticle(Article article)
        {
            _db.Articles.Update(article);
            return Save();
        }
    }
}
