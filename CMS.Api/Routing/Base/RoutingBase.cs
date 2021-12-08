
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

            app.MapGet($"/{typeof(T).Name}/GetAll", async (R repository) =>
            {
                var result = await repository.GetAll();
                return Results.Ok(result);
            });

            app.MapGet($"/{typeof(T).Name}/GetById", async (string id, HttpContext http, R repository) =>
            {
                try
                {
                    var item = await repository.GetById(id);
                    if (item == null) return Results.NotFound($"Not found item with id : {id}");
                    return Results.Ok(item);
                }
                catch(Exception ex)
                {
                    Results.StatusCode(500);
                    return Results.Problem(ex.ToString());
                }
                
            });

            app.MapPost($"/{typeof(T).Name}/PostAsync", async (T model, HttpContext http, R repository) =>
            {
                try
                {
                    var item = await repository.Create(model);
                    return Results.Ok(item);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.ToString());
                }
            });

            app.MapPut($"/{typeof(T).Name}/PutAsync", async (object id, T model, HttpContext http, R repository) =>
            {
                try
                {
                    var item = await repository.GetById(id);
                    if (item == null) return Results.NotFound($"Not found item with id : {id}");
                    await repository.Update(model);
                    return Results.Ok(item);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.ToString());
                }

            });

            app.MapDelete($"/{typeof(T).Name}/Delete", async (object id, HttpContext http, R repository) =>
            {
                try
                {
                    var item = await repository.GetById(id);
                    if (item == null) return Results.NotFound($"Not found item with id : {id}");
                    await repository.Delete(item);
                    return Results.Ok(item);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.ToString());
                }

            });

            app.MapDelete($"/{typeof(T).Name}/BulkDelete", async (string ids, HttpContext http, R repository) =>
            {
                try
                {
                    List<T> lstDelete = new();
                    IEnumerable<object> lstObjects = ids.Split(",").ToList();
                    foreach (var obj in lstObjects)
                    {
                        var existsItem = await repository.GetById(obj);
                        if (existsItem == null) return Results.NotFound($"Not found item with id : {obj}");
                        lstDelete.Add(existsItem);
                    }
                    await repository.BulkDelete(lstDelete);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.ToString());
                }

            });

        }      
    }
}
