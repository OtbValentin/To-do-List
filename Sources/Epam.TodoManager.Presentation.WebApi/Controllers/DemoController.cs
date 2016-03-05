using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.TodoManager.Presentation.WebApi.Models;
using Epam.TodoManager.Presentation.WebApi.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    public class DemoController : ApiController
    {
        private ApplicationUserManager manager;

        public DemoController()
        {
            manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        [Route("api/Demo/1")]
        [HttpGet]
        public string NoAuth()
        {
            return "no secret";
        }

        [Route("api/Demo/2"), HttpGet, Authorize]
        public string Auth()
        {
            return "secret";
        }

        [Route("api/Demo/3")]
        [HttpGet]
        public DemoModel Demo3()
        {
            return new DemoModel()
            {
                StringProp = "string1",
                IntProp = 115
            };
        }
        
        [Route("api/Demo/4")]
        [HttpPost]
        public void Demo4([FromBody] DemoModel model)
        {
            return;
        }

        [Route("api/Demo/Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register([FromBody] RegistrationData data)
        {
            var result = await manager.CreateAsync(new ApplicationUser() { UserName = data.Email }, data.Password);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors.Aggregate((errors, error) => $"{error}, \n {error}"));
        }
    }
}
