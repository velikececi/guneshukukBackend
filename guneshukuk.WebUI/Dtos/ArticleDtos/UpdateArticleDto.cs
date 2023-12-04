namespace guneshukuk.WebUI.Dtos.ArticleDtos
{
    public class UpdateArticleDto
    {
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
        public string ArticleImageUrl { get; set; }
        public string ArticleContent { get; set; }
	}
}
