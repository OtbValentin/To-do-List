using AutoMapper;
using Epam.TodoManager.BusinessLogic.TodoListService;
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
    public class TodoListsController : ApiController
    {
        private ITodoListService service;
        private IMapper mapper;
        private ApplicationUserManager Manager =>
            Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public TodoListsController(ITodoListService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/TodoLists
        public async Task<IHttpActionResult> Get()
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            IEnumerable<DomainModel.Entities.TodoList> lists;
            try
            {
                lists = service.GetTodoLists(user.Id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Json(lists.Select(list => mapper.Map<TodoList>(list)));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            DomainModel.Entities.TodoList list;
            try
            {
                list = service.GetTodoList(user.Id, id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Json(mapper.Map<TodoList>(list));
        }

        // POST: api/TodoLists
        public async Task<IHttpActionResult> Post([FromBody] string title)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            service.AddTodoList(user.Id, title);
            return Ok();
        }

        [HttpPost, Route("/api/TodoLists/{listId}/Shift")]
        public async Task<IHttpActionResult> ShiftTodoItem(int listId, [FromUri] int itemId, [FromUri] int index)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            try
            {
                service.ShiftTodo(user.Id, listId, itemId, index);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        // DELETE: api/TodoLists/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            var user = await Manager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return InternalServerError();

            try
            {
                service.RemoveTodoList(user.Id, id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }
    }
}
