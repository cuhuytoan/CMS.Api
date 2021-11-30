
namespace CMS.Api.Routing.Base
{
    public interface IRoutingWrapper
    {
        void MapAll();
        ISettingRouting SettingRouting { get; }
        
    }
    public class RoutingWrapper : IRoutingWrapper
    {
        private WebApplication app { get; set; }
        private IServiceProvider provider;        
        private ISettingRouting _settingRouting;
        public RoutingWrapper(WebApplication app, IServiceProvider provider )
        {
            this.app = app;
            this.provider = provider;          
        }
        public ISettingRouting SettingRouting
        {
            get
            {
                if (_settingRouting == null)
                {                
                    _settingRouting = new SettingRouting(app,provider.GetRequiredService<ISettingRepository>());
                }

                return _settingRouting;
            }
        }
        public void MapAll()
        {
            SettingRouting.MapAll();
        }
    }
}
