using CMS.Data.ModelDTO;
using CMS.Data.ModelEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CmsContext CmsContext { get; set; }
        private DbSet<T> TEntity = null;

        public RepositoryBase(CmsContext CmsContext)
        {
            this.CmsContext = CmsContext;
            TEntity = CmsContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await TEntity.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await TEntity.FindAsync(id);
        }

        public async Task<VirtualizeResponse<T>> GetAllWithPaging(int page , int pageSize )
        {
            VirtualizeResponse<T> entity = new();
            entity.TotalSize = TEntity.Count();
            entity.Items = await TEntity.Skip(page * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await TEntity.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            var obj = await TEntity.AddAsync(entity);
            await CmsContext.SaveChangesAsync();
            return obj.Entity;
        }

        public void Update(T entity)
        {
            TEntity.Update(entity);
            CmsContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            TEntity.Remove(entity);
            CmsContext.SaveChanges();
        }

        public void BulkDelete(IEnumerable<T> lstEntity)
        {
            TEntity.RemoveRange(lstEntity);
            CmsContext.SaveChanges();
        }
    }
}