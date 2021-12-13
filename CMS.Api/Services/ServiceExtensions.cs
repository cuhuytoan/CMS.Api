
using Microsoft.AspNetCore.Identity;

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
            services.RegisterAssemblyPublicNonGenericClasses(Utils.ListTypeRepository().ToArray())
                 .Where(x => x.Name.EndsWith("Repository"))
                 .AsPublicImplementedInterfaces(ServiceLifetime.Transient);           
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>(options => { });
            new IdentityBuilder(typeof(ApplicationUser), typeof(IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            services.Configure<IdentityOptions>(options =>
            {
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Default User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            });
          

        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {

        }
       
    }
}
