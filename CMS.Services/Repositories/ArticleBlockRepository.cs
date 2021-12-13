using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IArticleBlockRepository : IRepositoryBase<ArticleBlock>
    {
      
    }
   
    public class ArticleBlockRepository : RepositoryBase<ArticleBlock>, IArticleBlockRepository
    {
        public ArticleBlockRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}