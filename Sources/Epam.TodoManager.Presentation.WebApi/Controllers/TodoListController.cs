using Epam.TodoManager.Presentation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    public class TodoListController : ApiController
    {
        // GET: api/TodoList
        public IEnumerable<TodoList> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/TodoList/5
        public TodoList Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/TodoList
        public void Post([FromBody] TodoList value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/TodoList/5
        public void Put(int id, [FromBody] TodoList value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/TodoList/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
