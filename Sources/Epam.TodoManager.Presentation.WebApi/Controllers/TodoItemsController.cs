using AutoMapper;
using Epam.TodoManager.BusinessLogic.TodoListService;
using Epam.TodoManager.BusinessLogic.TodoService;
using Epam.TodoManager.Presentation.WebApi.Identity;
using Epam.TodoManager.Presentation.WebApi.Models;
using Microsoft.AspNet.Identity;
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

        public TodoItemsController(ITodoListService listService, ITodoService itemService, IMapper mapper)
        {
            this.listService = listService;
            this.itemService = itemService;
        }

        // GET: api/TodoItems
        public IHttpActionResult Get([FromUri] int listId)
        {
            IEnumerable<DomainModel.Entities.Todo> items;
            try
            {
                items = listService.GetTodoList(User.Identity.GetUserId<int>(), listId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Json(items.Select(item => item.ToApiModel()));
        }

        // GET: api/TodoItems/5
        public IHttpActionResult Get(int id, [FromUri] int listId)
        {
            IEnumerable<DomainModel.Entities.Todo> items;
            try
            {
                items = listService.GetTodoList(User.Identity.GetUserId<int>(), listId);
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
        public IHttpActionResult Post([FromBody] NewTodoItem newItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                listService.AddTodo(User.Identity.GetUserId<int>(), newItem.List, newItem.Text);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        [HttpPost, Route("api/TodoItems/{id}/Move")]
        public IHttpActionResult MoveToList(int id, 
            [FromUri(Name = "fromList")] int fromListId, [FromUri(Name = "toList")] int toListId)
        {
            try
            {
                itemService.MoveTodoToAnotherList(User.Identity.GetUserId<int>(), fromListId, id, toListId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] UpdatedTodoItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Identity.GetUserId<int>();

            var dbItem = listService.GetTodoList(userId, item.List).FirstOrDefault(i => i.Id == id);

            try
            {
                if (item.Text != dbItem.Text)
                {
                    itemService.RenameTodo(userId, item.List, id, item.Text);
                }

                if (item.Note != dbItem.Note)
                {
                    itemService.EditTodoNote(userId, item.List, id, item.Note);
                }

                if (item.IsCompleted.HasValue && item.IsCompleted != dbItem.IsCompleted)
                {
                    if (item.IsCompleted.Value)
                    {
                        itemService.CompleteTodo(userId, item.List, id);
                    }
                    else
                    {
                        itemService.MarkTodoAsUncompleted(userId, item.List, id);
                    }
                }

                if (item.DueDate != dbItem.DueDate)
                {
                    itemService.SetTodoDueDate(userId, item.List, id, item.DueDate);
                }
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // DELETE: api/TodoItems/5
        public IHttpActionResult Delete(int id, [FromUri] int listId)
        {
            try
            {
                listService.RemoveTodo(User.Identity.GetUserId<int>(), listId, id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }
    }
}
