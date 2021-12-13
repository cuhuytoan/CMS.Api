using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IAspNetRolesRepository : IRepositoryBase<AspNetRoles>
    {
        Task<List<AspNetRoles>> GetLstRolesByUserId(string userId);
    }
   
    public class AspNetRolesRepository : RepositoryBase<AspNetRoles>, IAspNetRolesRepository
    {
        public AspNetRolesRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }

        public async Task<List<AspNetRoles>> GetLstRolesByUserId(string userId)
        {            
            return await CmsContext.AspNetRoles
                  .FromSqlRaw(
                    $"SELECT B.* FROM AspnetUserRoles A JOIN AspNetRoles B ON A.RoleId = B.Id WHERE A.UserId = '{userId}'")
                .AsNoTracking()
                .ToListAsync();            
        }

    }
}