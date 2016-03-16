using AutoMapper;
using Epam.TodoManager.BusinessLogic.UserService;
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
    public class AccountController : ApiController
    {
        private ApplicationUserManager Manager =>
            Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        private IUserService userService;

        public AccountController(IUserService service)
        {
            this.userService = service;
        }

        // GET: api/Account
        public async Task<User> Get()
        {
            var user = await Manager.FindByIdAsync(User.Identity.GetUserId<int>());
            return user.ToApiModel();
        }

        // POST: api/Account
        [AllowAnonymous]
        public async Task<IHttpActionResult> Post([FromBody] NewUser value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = value.ToAppUser();
            var result = await Manager.CreateAsync(newUser, value.Password);

            if (!result.Succeeded)
                return BadRequest(AggregateErrors(result.Errors));
            else
                return Ok();
        }

        // PUT: api/Account/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] UpdatedUser value)
        {
            var existingUser = await Manager.FindByIdAsync(User.Identity.GetUserId<int>());
            if (existingUser == null)
                return InternalServerError();

            if (value.Id.HasValue)
                if (value.Id != existingUser.Id || id != existingUser.Id)
                    return Unauthorized();

            try
            {
                if (value.Name != null && value.Name != existingUser.UserName)
                    userService.ChangeName(id, value.Name);
                if (value.Email != null && value.Email != existingUser.Name)
                    userService.ChangeEmail(id, value.Email);
                if (value.Password != null)
                {
                    var validationResult = await Manager.PasswordValidator.ValidateAsync(value.Password);
                    if (!validationResult.Succeeded)
                        return BadRequest(AggregateErrors(validationResult.Errors));

                    var passwordHash = Manager.PasswordHasher.HashPassword(value.Password);
                    userService.ChangePassword(id, passwordHash);
                }
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        private string AggregateErrors(IEnumerable<string> errors)
        {
            return errors.Aggregate((result, error) => $"{result} \n{error}");
        }
    }
}
