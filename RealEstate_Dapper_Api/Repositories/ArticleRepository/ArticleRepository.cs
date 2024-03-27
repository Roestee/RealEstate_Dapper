using Dapper;
using RealEstate_Dapper_Api.Dtos.ArticleDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ArticleRepository
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly Context _context;

        public ArticleRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultArticleDto>> GetAllArticleAsync()
        {
            var query = "Select * From Article";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultArticleDto>(query);
                return values.ToList();
            }
        }

        public async void CreateArticle(CreateArticleDto articleDto)
        {
            var query = "insert into Article (Icon, Title, Description) values (@icon, @title, @description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", articleDto.Icon);
            parameters.Add("@title", articleDto.Title);
            parameters.Add("@description", articleDto.Description);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteArticle(int id)
        {
            var query = "Delete from Article Where ArticleId = @articleId";
            var parameters = new DynamicParameters();
            parameters.Add("@articleId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var query =
                "Update Article Set Icon=@icon, Title=@title, Description=@description where ArticleId=@articleId";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateArticleDto.Icon);
            parameters.Add("@title", updateArticleDto.Title);
            parameters.Add("@description", updateArticleDto.Description);
            parameters.Add("@articleId", updateArticleDto.ArticleId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultArticleDto> GetArticle(int id)
        {
            var query = "Select * From Article Where ArticleId=@articleId";
            var parameters = new DynamicParameters();
            parameters.Add("@articleId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultArticleDto>(query, parameters);
                return value;
            }
        }
    }
}
