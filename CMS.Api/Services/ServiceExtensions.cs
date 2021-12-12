
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
            //Cookie
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.Cookie.Name = "YourAppCookieName";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Identity/Account/Login";
            //    // ReturnUrlParameter requires 
            //    //using Microsoft.AspNetCore.Authentication.Cookies;
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //});

        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {

        }
       
    }
}
