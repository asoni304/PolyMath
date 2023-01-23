using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyMathAPI.Models;
using PolyMathAPI.Models.Dtos;
using PolyMathAPI.Repository.IRepository;
using System.Collections.Generic;

namespace PolyMathAPI.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _gRepo;
        private readonly IMapper _mapper;
        public GenresController(IGenreRepository gRepo, IMapper mapper)
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
            var objList = _gRepo.GetGenres();
            var objDto = new List<GenreDto>();

            foreach (var obj in objList)
            { 
                objDto.Add(_mapper.Map<GenreDto>(obj));
            }

            return Ok(objDto);
        }

        /// <summary>
        /// Get a single Genre
        /// </summary>
        /// <param name="genreId">The Id of the Genre </param>
        /// <returns></returns>

        [HttpGet("{genreId:int}", Name = "GetGenre")]
        [ProducesResponseType(200, Type = typeof(GenreDto))]
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(404)] //not found
        [ProducesDefaultResponseType] // default for any other errors 
        public IActionResult GetGenre(int genreId) {
            var obj = _gRepo.GetGenre(genreId);
            if(obj== null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<GenreDto>(obj);
            return Ok(objDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GenreDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // bad request
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)]
        public IActionResult CreateGenre([FromBody] GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_gRepo.GenreExists(genreDto.Name))
            {
                ModelState.AddModelError("", $"The Genre {genreDto.Name} Exists!");
                return StatusCode(404, ModelState);
            }


            var genreObj = _mapper.Map<Genre>(genreDto);

            if (!_gRepo.CreateGenre(genreObj))
            {
                ModelState.AddModelError("", $"Something went wrong when adding the new genre {genreObj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetGenre", new {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                genreId = genreObj.Id }, genreObj);


        }

        [HttpPatch("{genreId:int}", Name = "UpdateGenre")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)] //internal server error

        public IActionResult UpdateGenre(int genreId, [FromBody] GenreDto genreDto)
        {
            if (genreDto == null || genreId != genreDto.Id)
            {
                return BadRequest(ModelState);
            }

            var genreObj = _mapper.Map<Genre>(genreDto);

            if (!_gRepo.UpdateGenre(genreObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {genreObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{genreId:int}", Name = "DeleteGenre")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)] //not found
        [ProducesResponseType(500)]

        public IActionResult DeleteGenre(int genreId)
        {
            if (!_gRepo.GenreExists(genreId))
            {
                return NotFound();
            }
            var genreObj = _gRepo.GetGenre(genreId);

            if (!_gRepo.DeleteGenre(genreObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the genre {genreObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
