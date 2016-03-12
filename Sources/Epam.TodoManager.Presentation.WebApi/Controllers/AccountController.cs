using Epam.TodoManager.Presentation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        // GET: api/Account
        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Account/5
        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Account
        public void Post([FromBody] User value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody] User value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
