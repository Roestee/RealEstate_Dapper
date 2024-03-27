namespace RealEstate_Dapper_Api.Dtos.ArticleDtos
{
    public class UpdateArticleDto
    {
        public int ArticleId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
