using AutoMapper;
using Epam.TodoManager.BusinessLogic.UserService;
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
    public class AccountController : ApiController
    {
        private IMapper mapper;
        private ApplicationUserManager Manager =>
            Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        private IUserService userService;

        public AccountController(IUserService service, IMapper mapper)
        {
            this.userService = service;
            this.mapper = mapper;
        }

        // GET: api/Account
        public User Get()
        {
            var user = Manager.FindByNameAsync(User.Identity.Name);
            return mapper.Map<User>(user);
        }

        // POST: api/Account
        [AllowAnonymous]
        public async Task<IHttpActionResult> Post([FromBody] NewUser value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = mapper.Map<ApplicationUser>(value);
            var result = await Manager.CreateAsync(newUser, value.Password);

            if (!result.Succeeded)
                return BadRequest(AggregateErrors(result.Errors);
            else
                return Ok();
        }

        // PUT: api/Account/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] UpdatedUser value)
        {
            var existingUser = await Manager.FindByNameAsync(User.Identity.Name);
            if (existingUser == null)
                return InternalServerError();

            if (value.Id != existingUser.Id || id != existingUser.Id)
                return Unauthorized();

            if (value.Name != existingUser.UserName)
                userService.ChangeName(id, value.Name);
            if (value.Email != existingUser.Name)
                userService.ChangeEmail(id, value.Email);
            if (value.Password != null)
            {
                var validationResult = await Manager.PasswordValidator.ValidateAsync(value.Password);
                if (!validationResult.Succeeded)
                    return BadRequest(AggregateErrors(validationResult.Errors));

                userService.ChangePassword(id, value.Password);
            }

            return Ok();
        }

        private string AggregateErrors(IEnumerable<string> errors)
        {
            return errors.Aggregate((result, error) => $"{result} \n{error}");
        }
    }
}
