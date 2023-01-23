using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyMathAPI.Models;
using PolyMathAPI.Models.Dtos;
using PolyMathAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace PolyMathAPI.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/articles")]
    
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepo;
        public ArticlesController(IArticleRepository articleRepo, IMapper mapper)
        {
            _articleRepo = articleRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ArticleDto>))]
        [ProducesResponseType(400)]


        public IActionResult GetArticles()
        {
            var objList = _articleRepo.GetAllArticles(); // to avoid exposing our model we return the data in dto 
            var objDto = new List<ArticleDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ArticleDto>(obj));
            }

            return Ok(objDto);
        }

        /// <summary>
        /// Get Single Article
        /// </summary>
        /// <param name="articleId">The article id</param>
        /// <returns></returns>

        [HttpGet("{articleId:int}", Name = "GetArticle")]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        [ProducesResponseType(404)] //not found
        [ProducesDefaultResponseType] // default for any other errors 
       // [Authorize(Roles = "Admin")]
        public IActionResult GetArticle(int articleId)
        {
            var obj = _articleRepo.GetArticleInGenre(articleId);

            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<ArticleDto>(obj);

            return Ok(objDto);
        }

        /// <summary>
        /// Get All Articles in A Specific Genre
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>

        [HttpGet("[action]/{genreId:int}")]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(404)] //not found
        [ProducesDefaultResponseType] // default for any other errors 
        public IActionResult GetArticleInGenre(int genreId)
        {
            var objList = _articleRepo.GetAllArticlesInGenre(genreId);

            if (objList == null)
            {
                return NotFound();
            }

            var objDto = new List<ArticleDto>();


            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ArticleDto>(obj));
            }



            return Ok(objDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // bad request
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)]
        public IActionResult CreateArticle([FromBody] ArticleCreateDto articleDto)
        {
            if (articleDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_articleRepo.ArticleExists(articleDto.Title))
            {
                ModelState.AddModelError("", $"Article {articleDto.Title} Exists!");
                return StatusCode(404, ModelState);
            }


            var articleObj = _mapper.Map<Article>(articleDto);

            if (!_articleRepo.CreateArticle(articleObj))
            {
                ModelState.AddModelError("", $"Something went wrong when adding the record {articleObj.Title}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetArticle", new { articleId = articleObj.Id }, articleObj);
        }

        [HttpPatch("{articleId:int}", Name = "UpdateArticle")]

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //not found
        [ProducesResponseType(500)] //internal server error

        public IActionResult UpdateArticle(int articleId, [FromBody] ArticleUpdateDto articleDto)
        {
            if (articleDto == null || articleId != articleDto.Id)
            {
                return BadRequest(ModelState);
            }

            var articleObj = _mapper.Map<Article>(articleDto);

            if (!_articleRepo.UpdateArticle(articleObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {articleObj.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{articleId:int}", Name = "DeleteArticle")]

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)] //not found
        [ProducesResponseType(500)]

        public IActionResult DeleteArticle(int articleId)
        {
            if (!_articleRepo.ArticleExists(articleId))
            {
                return NotFound();
            }
            var articleObj = _articleRepo.GetArticleInGenre(articleId);

            if (!_articleRepo.DeleteArticle(articleObj))
            {
                ModelState.AddModelError("", $"Something went wrong when delete the record {articleObj}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
