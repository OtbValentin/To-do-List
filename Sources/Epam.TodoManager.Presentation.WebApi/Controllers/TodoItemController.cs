using Epam.TodoManager.Presentation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    public class TodoItemController : ApiController
    {
        // GET: api/TodoItem
        public IEnumerable<TodoItem> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/TodoItem/5
        public TodoItem Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/TodoItem
        public void Post([FromBody] TodoItem value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/TodoItem/5
        public void Put(int id, [FromBody] TodoItem value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/TodoItem/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
