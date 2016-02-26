using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ToDoList.WebApi.Identity
{
    public class ApplicationUser : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}