using CMS.Data.ModelEntity;
using CMS.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IDbContextFactory<CmsContext> _cmsContext { get; set; }
     
        private ISettingRepository _setting;
        
        public RepositoryWrapper(IDbContextFactory<CmsContext> CmsContext)
        {
            _cmsContext = CmsContext;           
        }
        
        
        public ISettingRepository Setting
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new SettingRepository(_cmsContext.CreateDbContext());
                }

                return _setting;
            }
        }

        public void Save()
        {
            
            using var CmsContext = _cmsContext.CreateDbContext();
            CmsContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            using var CmsContext = _cmsContext.CreateDbContext();
            return CmsContext.SaveChangesAsync();
        }
        
       
    }
}