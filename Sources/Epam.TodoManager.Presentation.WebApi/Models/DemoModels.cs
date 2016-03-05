using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Models
{
    public class DemoModel
    {
        public string StringProp { get; set; }
        public int IntProp { get; set; }
    }

    public class RegistrationData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}