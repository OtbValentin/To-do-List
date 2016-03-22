using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Cors;

namespace Epam.TodoManager.Presentation.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            var config = new HttpConfiguration();

            IdentityConfig.Configure(app);
            AuthConfig.Configure(app);

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}