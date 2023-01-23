using PolyMathAPI.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace PolyMathAPI.Repository.IRepository
{
    public interface IArticleRepository
    {
        //all methods we want to perform ,crud operations

        ICollection<Article> GetAllArticles(); //get all articles

        ICollection<Article> GetAllArticlesInGenre(int genreId); //get all articles in a genre
        Article GetArticleInGenre(int articleId); //get one article

        bool ArticleExists(string name); //if article exists based on name

        bool ArticleExists(int id);  //if article exists based on id

        bool CreateArticle(Article article);

        bool UpdateArticle(Article article);
        bool DeleteArticle(Article article);

        bool Save();
    }
}
