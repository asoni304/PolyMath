using PolyMathWeb.Models;
using PolyMathWeb.Repository.IRepository;
using System.Net.Http;

namespace PolyMathWeb.Repository
{
    public class ArticleRepository:Repository<Article>,IArticleRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public ArticleRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
