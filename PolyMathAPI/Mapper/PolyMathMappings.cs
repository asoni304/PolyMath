
using AutoMapper;
using PolyMathAPI.Models;
using PolyMathAPI.Models.Dtos;

namespace PolyMathAPI.Mapper
{
    public class PolyMathMappings : Profile
    {
        public PolyMathMappings() 
        {
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Article, ArticleCreateDto>().ReverseMap();
            CreateMap<Article, ArticleUpdateDto>().ReverseMap();
        }
    }
}
