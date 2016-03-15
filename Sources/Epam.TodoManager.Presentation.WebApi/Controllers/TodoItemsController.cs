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

        [HttpPost, Route("api/TodoItems/{id}/Move")]
        public async Task<IHttpActionResult> MoveToList(int id, 
            [FromUri(Name = "fromList")] int fromListId, [FromUri(Name = "toList")] int toListId)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            try
            {
                itemService.MoveTodoToAnotherList(user.Id, fromListId, id, toListId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        public async Task<IHttpActionResult> Put(int id, [FromBody] UpdatedTodoItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            try
            {
                if (item.Text != null)
                    itemService.RenameTodo(user.Id, item.List, id, item.Text);

                if (item.Note != null)
                    itemService.EditTodoNote(user.Id, item.List, id, item.Note);

                if (item.IsCompleted.HasValue)
                {
                    if (item.IsCompleted.Value)
                        itemService.CompleteTodo(user.Id, item.List, id);
                    else
                        itemService.MarkTodoAsUncompleted(user.Id, item.List, id);
                }

                if (item.DueDate.HasValue)
                    itemService.SetTodoDueDate(user.Id, item.List, id, item.DueDate.Value);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

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
