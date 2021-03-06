
namespace CMS.Api.Routing
{
    public interface IArticleRouting : IRoutingBase<Article,IArticleRepository>
    {
        new Task MapAll();
    }
    public class ArticleRouting : RoutingBase<Article, IArticleRepository>, IArticleRouting
    {
        public ArticleRouting(WebApplication app, IArticleRepository repository) : base(app, repository)
        {
        }

        public override async Task MapAll()
        {
            await base.MapAll();
        }
    }
}
