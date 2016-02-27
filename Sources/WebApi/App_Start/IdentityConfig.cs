using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.ToDoList.WebApi.Identity;

namespace Epam.ToDoList.WebApi
{
    public static class IdentityConfig
    {
        public static void Configure(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationUserManager.Create);
        }
    }
}