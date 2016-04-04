using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.TodoManager.Presentation.WebApi.Identity;
using Ninject;

namespace Epam.TodoManager.Presentation.WebApi
{
    public static class IdentityConfig
    {
        public static void Configure(IAppBuilder app, IKernel kernel)
        {
            //app.CreatePerOwinContext(ApplicationUserManager.Create);
            app.CreatePerOwinContext(kernel.Get<ApplicationUserManager>);
        }
    }

    public static class NinjectKernelExtensions
    {
        public static T Get<T>(this IKernel kernel)
        {
            return kernel.Get<T>(new Ninject.Parameters.IParameter[0]);
        }

        public static T TryGet<T>(this IKernel kernel)
        {
            return kernel.TryGet<T>(new Ninject.Parameters.IParameter[0]);
        }
    }
}