using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IAspNetUserRolesRepository : IRepositoryBase<AspNetUserRoles>
    {
       
    }
   
    public class AspNetUserRolesRepository : RepositoryBase<AspNetUserRoles>, IAspNetUserRolesRepository
    {
        public AspNetUserRolesRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }

       

    }
}