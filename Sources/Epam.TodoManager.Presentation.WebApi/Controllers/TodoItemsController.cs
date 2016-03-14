using AutoMapper;
using Epam.TodoManager.BusinessLogic.TodoListService;
using Epam.TodoManager.BusinessLogic.TodoService;
using Epam.TodoManager.Presentation.WebApi.Identity;
using Epam.TodoManager.Presentation.WebApi.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    [Authorize]
    public class TodoItemsController : ApiController
    {
        private ITodoListService listService;
        private ITodoService itemService;
        private IMapper mapper;
        private ApplicationUserManager Manager =>
            Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public TodoItemsController(ITodoListService listService, ITodoService itemService, IMapper mapper)
        {
            this.listService = listService;
            this.itemService = itemService;
            this.mapper = mapper;
        }

        // GET: api/TodoItems
        public async Task<IHttpActionResult> Get([FromUri] int listId)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            IEnumerable<DomainModel.Entities.Todo> items;
            try
            {
                items = listService.GetTodoList(user.Id, listId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Json(items.Select(item => mapper.Map<TodoItem>(item)));
        }

        // GET: api/TodoItems/5
        public async Task<IHttpActionResult> Get(int id, [FromUri] int listId)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            IEnumerable<DomainModel.Entities.Todo> items;
            try
            {
                items = listService.GetTodoList(user.Id, listId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            var item = items.FirstOrDefault(todoItem => todoItem.Id == id);
            if (item == null)
                return BadRequest("An item with the specified Id could not be found.");

            return Json(item);
        }

        // POST: api/TodoItems
        public async Task<IHttpActionResult> Post([FromBody] NewTodoItem newItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            try
            {
                listService.AddTodo(user.Id, newItem.List, newItem.Text);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // possibly split into individual actions for each property change
        // PUT: api/TodoItems/5
        //public void Put(int id, [FromBody] TodoItem value)
        //{
        //    throw new NotImplementedException();
        //}

        // DELETE: api/TodoItems/5
        public async Task<IHttpActionResult> Delete(int id, [FromUri] int listId)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            try
            {
                listService.RemoveTodo(user.Id, listId, id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }
    }
}
