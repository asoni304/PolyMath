using PolyMathWeb.Models;
using PolyMathWeb.Repository.IRepository;
using System.Net.Http;

namespace PolyMathWeb.Repository
{
    public class GenreRepository: Repository<Genre>,IGenreRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public GenreRepository(IHttpClientFactory clientFactory):base(clientFactory) 
        {
            _clientFactory = clientFactory;
        }
    }
}   
