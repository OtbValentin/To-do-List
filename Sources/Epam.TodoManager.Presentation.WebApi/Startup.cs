using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Epam.ToDoList.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IdentityConfig.Configure(app);
            AuthConfig.Configure(app);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}