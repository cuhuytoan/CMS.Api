using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IArticleBlockArticleRepository : IRepositoryBase<ArticleBlockArticle>
    {
      
    }
   
    public class ArticleBlockArticleRepository : RepositoryBase<ArticleBlockArticle>, IArticleBlockArticleRepository
    {
        public ArticleBlockArticleRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}