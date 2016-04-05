using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Epam.TodoManager.Presentation.WebApi.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
            UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public static ApplicationUserManager Create()
        {
            throw new NotSupportedException();

            //var manager = new ApplicationUserManager(new ApplicationUserStore());

            ////TODO: configure Identity policies
            //manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false
            //};

            //return manager;
        }
    }
}