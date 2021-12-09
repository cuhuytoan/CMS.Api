using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IArticleCommentRepository : IRepositoryBase<ArticleComment>
    {
      
    }
   
    public class ArticleCommentRepository : RepositoryBase<ArticleComment>, IArticleCommentRepository
    {
        public ArticleCommentRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}