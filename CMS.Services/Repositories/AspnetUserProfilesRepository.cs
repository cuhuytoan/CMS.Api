using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface IAspNetUserProfilesRepository : IRepositoryBase<AspNetUserProfiles>
    {
      Task<AspNetUserProfiles> GetByUserId(string userId);
    }
   
    public class AspNetUserProfilesRepository : RepositoryBase<AspNetUserProfiles>, IAspNetUserProfilesRepository
    {
        public AspNetUserProfilesRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }

        public async Task<AspNetUserProfiles> GetByUserId(string userId)
        {
            return await CmsContext.AspNetUserProfiles.FirstAsync(x => x.UserId == userId);
        }
    }
}