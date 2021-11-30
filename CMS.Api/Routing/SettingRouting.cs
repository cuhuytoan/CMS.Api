
namespace CMS.Api.Routing
{
    public interface ISettingRouting : IRoutingBase<Setting,ISettingRepository>
    {
        Task MapAll();
    }
    public class SettingRouting : RoutingBase<Setting, ISettingRepository>, ISettingRouting
    {
        public SettingRouting(WebApplication app, ISettingRepository repository) : base(app, repository)
        {
        }

        public async Task MapAll()
        {
            await MapBase();
        }
    }
}
