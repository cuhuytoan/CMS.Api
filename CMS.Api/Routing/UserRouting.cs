
using CMS.Api.Authorization;
using CMS.Api.Helpers;
using CMS.Data.ModelDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CMS.Api.Routing
{
    public interface IUserRouting : IRoutingBase<AspNetUsers, IUserRepository>
    {
        Task MapAll();
    }
    public class UserRouting : RoutingBase<AspNetUsers, IUserRepository>, IUserRouting
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserRouting(WebApplication app, IUserRepository repository) : base(app, repository)
        {
           
        }
        protected UserRouting(WebApplication app, IUserRepository repository,UserManager<IdentityUser> userManager,
         SignInManager<IdentityUser> signInManager) :this(app,repository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task MapAll()
        {
           
            app.MapPost($"/api/Login", async (LoginModel model,
                HttpContext http, IRepositoryWrapper repository, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings) =>
            {
                SumProfileResponseDTO response = new();
                var userExists = await userManager.FindByNameAsync(model.Email);
                if (userExists == null) return Results.BadRequest($"Không tồn tại tài khoản {model.Email}");
                IdentityUser user = new(model.Email);
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    response.Profile = await repository.AspNetUserProfiles.GetByUserId(userExists.Id);
                    response.ListRole = await repository.AspNetRoles.GetLstRolesByUserId(userExists.Id);
                    response.Token = jwtUtils.GenerateJwtToken(model);
                    var refreshToken = jwtUtils.GenerateRefreshToken(model.IPAddress);
                    response.RefreshToken.Add(refreshToken);

                    // remove old inactive refresh tokens from user based on TTL in app settings
                    response.RefreshToken.RemoveAll(x =>
                        !x.IsActive &&
                        x.Created.AddDays(appSettings.Value.RefreshTokenTTL) <= DateTime.UtcNow);
                    return Results.Ok(response);
                }
                else
                {
                    Results.StatusCode(401);
                    return Results.Problem("Thông tin đăng nhập không hợp lệ");
                }
                // return Results.Ok("sss");
            }).WithTags("AspNetUsers");

            await base.MapAll();
        }

    }
}
