using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using ApiService;
[assembly: OwinStartup(typeof(Startup))]
namespace ApiService
{
    /// <summary>
    /// Startup class for application starting configuration.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR(hubConfiguration);
        }
    }
}