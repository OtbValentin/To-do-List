using Epam.TodoManager.Presentation.WebApi.Identity;
using Microsoft.AspNet.Identity;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Infrastructure
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IUserStore<ApplicationUser, int>>().To<ApplicationUserStore>();
            Bind<ApplicationUserStore>().ToSelf();
            Bind<ApplicationUserManager>().ToSelf().InRequestScope(); //?
        }
    }
}