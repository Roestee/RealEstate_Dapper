using RealEstate_Dapper_Api.Dtos.ArticleDtos;

namespace RealEstate_Dapper_Api.Repositories.ArticleRepository
{
    public interface IArticleRepository
    {
        Task<List<ResultArticleDto>> GetAllArticleAsync();
        void CreateArticle(CreateArticleDto articleDto);
        void DeleteArticle(int id);
        void UpdateArticle(UpdateArticleDto updateArticleDto);
        Task<ResultArticleDto> GetArticle(int id);
    }
}
