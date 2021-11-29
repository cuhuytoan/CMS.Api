


using CMS.Services.Repositories;

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
            await MapGetAll();
        }
        private async Task MapGetAll()
        {
            app.MapGet($"/{typeof(T).Name}/GetAll", async (R repository) =>
            {
                var result = await repository.GetAll();
                return Results.Ok(result);
            });
        }
    }
}
