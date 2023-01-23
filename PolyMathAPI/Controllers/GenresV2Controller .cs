using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyMathAPI.Models;
using PolyMathAPI.Models.Dtos;
using PolyMathAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace PolyMathAPI.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/genres")]
    [ApiVersion("2.0")]
    [ApiController]
    public class GenresV2Controller : ControllerBase
    {
        private readonly IGenreRepository _gRepo;
        private readonly IMapper _mapper;
        public GenresV2Controller(IGenreRepository gRepo, IMapper mapper)
        {
            _gRepo= gRepo;
            _mapper= mapper;    
        }
        /// <summary>
        /// Get List Of All Genres
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GenreDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetGenres() { 
        //to avoid exposing our model we return in dto format
            var obj = _gRepo.GetGenres().FirstOrDefault();
            

           

            return Ok(_mapper.Map<GenreDto>(obj));
        }
    }
}
