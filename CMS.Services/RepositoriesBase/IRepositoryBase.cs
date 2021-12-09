using CMS.Data.ModelDTO;
using CMS.Data.ModelFilter;
using System.Linq.Expressions;

namespace CMS.Services.RepositoriesBase
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);        
        Task<T> GetByGuidId(Guid id);
        Task<T> GetByIdNoTracking(int id);
        Task<T> GetByGuidIdNoTracking(Guid id);
        Task<VirtualizeResponse<T>> GetByFilter(FilterDTO model);
        Task<VirtualizeResponse<T>> GetAllWithPaging(int page , int pageSize);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task BulkDelete(IEnumerable<T> lstEntity);        
    }
}