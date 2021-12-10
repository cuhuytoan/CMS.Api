
namespace CMS.Api.Routing
{
    public interface IArticleRouting : IRoutingBase<Article,IArticleRepository>
    {
        Task MapAll();
    }
    public class ArticleRouting : RoutingBase<Article, IArticleRepository>, IArticleRouting
    {
        public ArticleRouting(WebApplication app, IArticleRepository repository) : base(app, repository)
        {
        }

        public async Task MapAll()
        {
            await MapBase();
        }
    }
}
