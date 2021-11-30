
namespace CMS.Api.Routing.Base
{
    public interface IRoutingBase<T,R>
    {
        Task MapBase();
        
    }    
    public abstract class RoutingBase<T,R> : IRoutingBase<T,R> where R : IRepositoryBase<T>
    {                                   
        protected WebApplication app { get; set; }

        protected readonly R repository;
        public RoutingBase(WebApplication app , R repository)
        {
            this.app = app;
            this.repository = repository;
        }

        public async Task MapBase()
        {
            await GetAll();
          
            app.MapGet($"/{typeof(T).Name}/GetById", async (int id,HttpContext http, R repository) =>
            {
                var item = await repository.GetById(id);
                if (item == null) return Results.NotFound($"Not found item with id : {id}");
                return Results.Ok(item);
            });
        }  
        private async Task GetAll()
        {
            app.MapGet($"/{typeof(T).Name}/GetAll", async (R repository) =>
            {
                var result = await repository.GetAll();
                return Results.Json(result);
            });
        }
        private async Task GetById()
        {
           
        }   
        
    }
}
