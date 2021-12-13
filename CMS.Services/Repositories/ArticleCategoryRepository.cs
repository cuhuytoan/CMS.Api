using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IArticleCategoryRepository : IRepositoryBase<ArticleCategory>
    {
      
    }
   
    public class ArticleCategoryRepository : RepositoryBase<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}