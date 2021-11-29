using CMS.Data;
using CMS.Data.ModelEntity;
using CMS.Services.Repositories;
using CMS.Services.RepositoriesBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace CMS.Api.Services
{
    public static class ServiceExtensions
    {

        public static void ConfigureLogging(this IServiceCollection services)
        {

        }
        public static void ConfigureConnectDB(this IServiceCollection services, string connectStrings)
        {
            services.AddDbContextFactory<CmsContext>(options =>
                options.UseSqlServer(connectStrings), ServiceLifetime.Transient);
        }
        public static void ConfigureConnectDBAuth(this IServiceCollection services, string connectStrings)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectStrings));

        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            
            
            var ressult = services.RegisterAssemblyPublicNonGenericClasses(Utils.ListTypeRepository().ToArray())
                 .Where(x => x.Name.EndsWith("Repository"))
                 .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
            var xxx = ressult.Count();

            
        }
       
    }
}
