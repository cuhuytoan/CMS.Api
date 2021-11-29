using CMS.Data.ModelEntity;
using CMS.Services.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Threading.Tasks;

namespace CMS.Services.Repositories
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
      
    }
   
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(CmsContext CmsDBContext) : base(CmsDBContext)
        {
        }
      
    }
}