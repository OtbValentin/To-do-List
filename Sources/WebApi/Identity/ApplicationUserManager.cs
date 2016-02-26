using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ToDoList.WebApi.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        private ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create()
        {
            var manager = new ApplicationUserManager(new ApplicationUserStore());

            //TODO: configure Identity policies

            return manager;
        }
    }
}