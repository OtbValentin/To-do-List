using Epam.TodoManager.Infrastructure.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Epam.TodoManager.Presentation.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            var kernel = new StandardKernel(new Infrastructure.NinjectModule(), new NinjectModule());

            IdentityConfig.Configure(app, kernel);
            AuthConfig.Configure(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseNinjectMiddleware(() => kernel);
            app.UseNinjectWebApi(config);
        }
    }
}
