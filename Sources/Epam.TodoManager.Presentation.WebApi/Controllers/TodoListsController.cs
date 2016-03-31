using AutoMapper;
using Epam.TodoManager.BusinessLogic.TodoListService;
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
    public class TodoListsController : ApiController
    {
        private ITodoListService service;

        public TodoListsController(ITodoListService service, IMapper mapper)
        {
            this.service = service;
        }

        // GET: api/TodoLists
        public IHttpActionResult Get()
        {
            IEnumerable<DomainModel.Entities.TodoList> lists;
            try
            {
                lists = service.GetTodoLists(User.Identity.GetUserId<int>());
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Json(lists.Select(list => list.ToPopulatedApiModel()));
        }

        public IHttpActionResult Get(int id)
        {
            DomainModel.Entities.TodoList list;
            try
            {
                list = service.GetTodoList(User.Identity.GetUserId<int>(), id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Json(list.ToPopulatedApiModel());
        }

        // POST: api/TodoLists
        public IHttpActionResult Post([FromBody] string title)
        {
            service.AddTodoList(User.Identity.GetUserId<int>(), title);
            return Ok();
        }

        [HttpPost, Route("api/TodoLists/{listId}/Shift")]
        public IHttpActionResult ShiftTodoItem(int listId, [FromUri] int itemId, [FromUri] int index)
        {
            try
            {
                service.ShiftTodo(User.Identity.GetUserId<int>(), listId, itemId, index);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // DELETE: api/TodoLists/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                service.RemoveTodoList(User.Identity.GetUserId<int>(), id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }
    }
}
