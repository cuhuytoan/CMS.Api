
namespace CMS.Api.Routing
{
    public interface ISettingRouting : IRoutingBase<Setting,ISettingRepository>
    {
        new Task MapAll();
    }
    public class SettingRouting : RoutingBase<Setting, ISettingRepository>, ISettingRouting
    {
        public SettingRouting(WebApplication app, ISettingRepository repository) : base(app, repository)
        {
        }

        public override async Task MapAll()
        {
            await base.MapAll();
        }
    }
}
