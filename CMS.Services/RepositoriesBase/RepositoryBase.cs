using CMS.Data.ModelDTO;
using CMS.Data.ModelEntity;
using CMS.Data.ModelFilter;
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

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await TEntity.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await TEntity.FindAsync(id);
        }
        public virtual async Task<T> GetByGuidId(Guid id)
        {
            return await TEntity.FindAsync(id);
        }
        public virtual async Task<T> GetByIdNoTracking(int id)
        {
            var et =  await TEntity.FindAsync(id);
            if (et != null)
            {
                CmsContext.Entry(et).State = EntityState.Detached;
            }
            return et;
        }

        public virtual async Task<T> GetByGuidIdNoTracking(Guid id)
        {
            var et = await TEntity.FindAsync(id);
            if (et != null)
            {
                CmsContext.Entry(et).State = EntityState.Detached;
            }
            return et;
        }
        public virtual async Task<VirtualizeResponse<T>> GetAllWithPaging(int page , int pageSize )
        {
            VirtualizeResponse<T> entity = new();
            entity.TotalSize = TEntity.Count();
            entity.Items = await TEntity.Skip((page-1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await TEntity.Where(expression).AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> Create(T entity)
        {
            var obj = await TEntity.AddAsync(entity);
            await CmsContext.SaveChangesAsync();
            return obj.Entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            CmsContext.Entry(entity).State = EntityState.Detached;
            TEntity.Update(entity);
            await CmsContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(T entity)
        {
            TEntity.Remove(entity);
            await CmsContext.SaveChangesAsync();
        }

        public virtual async Task BulkDelete(IEnumerable<T> lstEntity)
        {
            TEntity.RemoveRange(lstEntity);
            await CmsContext.SaveChangesAsync();
        }

        public virtual async Task<VirtualizeResponse<T>> GetByFilter(FilterDTO model)
        {
            VirtualizeResponse<T> result = new();      
            var resultFilter = await TEntity.AsQueryable().ToFilterView(model).ToListAsync();
            result.Items = resultFilter;
            result.TotalSize = 100;
            return result;
        }
    }
}