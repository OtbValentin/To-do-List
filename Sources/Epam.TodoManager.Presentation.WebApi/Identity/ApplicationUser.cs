using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Identity
{
    public class ApplicationUser : IUser<int>
    {
        public int Id { get; set; }

        //must be unique, so is used for storing email
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string Name { get; set; }
    }
}