﻿
namespace CMS.Api.Routing.Base
{
    public interface IRoutingWrapper
    {
        void MapAll();
        ISettingRouting SettingRouting { get; }
        IArticleRouting ArticleRouting { get; }
        
    }
    public class RoutingWrapper : IRoutingWrapper
    {
        private WebApplication app { get; set; }
        private IServiceProvider provider;        
        private ISettingRouting _settingRouting;
        private IArticleRouting _articleRouting;
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

        public IArticleRouting ArticleRouting
        {
            get
            {
                if (_articleRouting == null)
                {
                    _articleRouting = new ArticleRouting(app, provider.GetRequiredService<IArticleRepository>());
                }

                return _articleRouting;
            }
        }

        public void MapAll()
        {
            SettingRouting.MapAll();
            ArticleRouting.MapAll();
        }
    }
}
