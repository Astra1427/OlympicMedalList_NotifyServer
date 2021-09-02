using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(NotifyServer.Startup1))]

namespace NotifyServer
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //app.MapSignalR("/signalr",new HubConfiguration { 
            //    EnableJSONP = true,
                
            //});



            app.Map("/signalr", map =>
            {
                app.UseCors(CorsOptions.AllowAll);
                var hubconfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };
                map.RunSignalR(hubconfiguration);
            });

        }
    }
}
