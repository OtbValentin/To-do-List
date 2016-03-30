using AutoMapper;
using Epam.TodoManager.BusinessLogic.UserService;
using Epam.TodoManager.Presentation.WebApi.Identity;
using Epam.TodoManager.Presentation.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epam.TodoManager.Presentation.WebApi.Controllers
{
    [Authorize/*, EnableCors("*", "*", "*", SupportsCredentials = true)*/]
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
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var user = await Manager.FindByIdAsync(User.Identity.GetUserId<int>());
                return Json(user.ToApiModel());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Account
        [AllowAnonymous]
        public async Task<IHttpActionResult> Post([FromBody] NewUser value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = value.ToAppUser();
            IdentityResult result;
            try
            {
                result = await Manager.CreateAsync(newUser, value.Password);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            if (!result.Succeeded)
                return BadRequest(AggregateErrors(result.Errors));
            else
                return Ok();
        }

        // PUT: api/Account/5
        public async Task<IHttpActionResult> Put([FromBody] UpdatedUser value)
        {
            var existingUser = await Manager.FindByIdAsync(User.Identity.GetUserId<int>());
            if (existingUser == null)
                return InternalServerError();

            if (value.Id.HasValue)
                if (value.Id != existingUser.Id)
                    return Unauthorized();

            try
            {
                if (value.Name != null && value.Name != existingUser.UserName)
                    userService.ChangeName(existingUser.Id, value.Name);
                if (value.Email != null && value.Email != existingUser.Name)
                    userService.ChangeEmail(existingUser.Id, value.Email);
                if (value.Password != null)
                {
                    var validationResult = await Manager.PasswordValidator.ValidateAsync(value.Password);
                    if (!validationResult.Succeeded)
                        return BadRequest(AggregateErrors(validationResult.Errors));

                    var passwordHash = Manager.PasswordHasher.HashPassword(value.Password);
                    userService.ChangePassword(existingUser.Id, passwordHash);
                }
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok();
        }

        //[HttpPost, Route("api/Account/Avatar")]
        //public async Task<IHttpActionResult> SetAvatar()
        //{
        //    var files = HttpContext.Current.Request.Files;
        //    var images = new List<HttpPostedFile>();
        //    for (int i = 0; i < files.Count; i++)
        //    {
        //        var file = files[i];
        //        if (file.ContentType.StartsWith("image"))
        //            images.Add(file);
        //    }
        //    if (images.Count <= 0)
        //        return BadRequest("No image attached.");
        //    if (images.Count > 1)
        //        return BadRequest("Multiple images not supported.");

        //    var existingUser = await Manager.FindByIdAsync(User.Identity.GetUserId<int>());
        //    if (existingUser == null)
        //        return InternalServerError();

        //    var imageDataStream = images[0].InputStream;
        //    var imageData = (new BinaryReader(imageDataStream)).ReadBytes((int)imageDataStream.Length);
        //    try
        //    {
        //        //call BL
        //    }
        //    catch (ArgumentException exception)
        //    {
        //        return BadRequest(exception.Message);
        //    }

        //    return Ok();
        //}

        //[HttpGet, Route("/api/Account/Avatar")]
        //public async Task<IHttpActionResult> GetAvatar()
        //{
        //    var existingUser = await Manager.FindByIdAsync(User.Identity.GetUserId<int>());
        //    if (existingUser == null)
        //        return InternalServerError();

        //    byte[] data;
        //    try
        //    {
        //        data = null; //call BL
        //    }
        //    catch (ArgumentException exception)
        //    {
        //        return BadRequest(exception.Message);
        //    }

        //    var response = Request.CreateResponse(HttpStatusCode.OK);
        //    var content = new ByteArrayContent(data);
        //    response.Content = content;

        //    return ResponseMessage(response);
        //}

        private string AggregateErrors(IEnumerable<string> errors)
        {
            return errors.Aggregate((result, error) => $"{result} \n{error}");
        }
    }
}
