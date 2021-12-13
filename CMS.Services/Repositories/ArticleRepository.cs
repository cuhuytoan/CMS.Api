using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
      
    }
   
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}