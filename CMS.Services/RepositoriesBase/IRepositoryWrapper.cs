using CMS.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public interface IRepositoryWrapper
    {
        ISettingRepository Setting { get; }

        void Save();

        Task<int> SaveChangesAsync();

        
    }
}