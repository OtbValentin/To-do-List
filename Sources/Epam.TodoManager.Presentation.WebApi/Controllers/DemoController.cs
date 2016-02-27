using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    public class DemoController : ApiController
    {
        [Route("api/Demo/1")]
        [HttpGet]
        public string NoAuth()
        {
            return "no secret";
        }

        [Route("api/Demo/2")]
        public string Auth()
        {
            return "secret";
        }
    }
}
