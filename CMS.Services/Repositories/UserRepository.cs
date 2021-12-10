using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IUserRepository : IRepositoryBase<AspNetUsers>
    {
      
    }
   
    public class UserRepository : RepositoryBase<AspNetUsers>, IUserRepository
    {
        public UserRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}