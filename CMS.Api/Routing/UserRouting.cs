
using CMS.Data.ModelDTO;
using Microsoft.AspNetCore.Identity;

namespace CMS.Api.Routing
{
    public interface IUserRouting : IRoutingBase<AspNetUsers, IUserRepository>
    {
        Task MapAll();
    }
    public class UserRouting : RoutingBase<AspNetUsers, IUserRepository>, IUserRouting
    {
        public UserRouting(WebApplication app, IUserRepository repository) : base(app, repository)
        {
        }

        public async Task MapAll()
        {
            //await MapBase();
            app.MapPost($"/api/Login", async (LoginModel model, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                HttpContext http, IRepositoryWrapper repository) =>
            {
                var userExists = userManager.FindByNameAsync(model.Email);
                if (userExists == null) return Results.BadRequest($"Không tồn tại tài khoản {model.Email}");
                IdentityUser user = new(model.Email);
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
                if(result.Succeeded)
                {

                }    

            });
        }
    }
}
