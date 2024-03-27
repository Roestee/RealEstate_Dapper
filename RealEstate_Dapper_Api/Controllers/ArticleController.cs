using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ArticleDtos;
using RealEstate_Dapper_Api.Repositories.ArticleRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ArticleList()
        {
            var value = await _articleRepository.GetAllArticleAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
        {
            _articleRepository.CreateArticle(createArticleDto);
            return Ok("Article Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            _articleRepository.DeleteArticle(id);
            return Ok($"id= {id} Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            _articleRepository.UpdateArticle(updateArticleDto);
            return Ok("Article Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var value = await _articleRepository.GetArticle(id);
            return Ok(value);
        }
    }
}
