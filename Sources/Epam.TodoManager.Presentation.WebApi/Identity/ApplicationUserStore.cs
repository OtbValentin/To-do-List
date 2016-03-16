using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Epam.TodoManager.BusinessLogic.UserService;
using Epam.TodoManager.DomainModel.Entities;
using System.Net.Http;
using Epam.TodoManager.Presentation.WebApi.Infrastructure;
using AutoMapper;
using Epam.TodoManager.Presentation.WebApi.Models;

namespace Epam.TodoManager.Presentation.WebApi.Identity
{
    //TODO: implement additional interfaces (IXxxStore) if necessary
    public class ApplicationUserStore : IUserStore<ApplicationUser, int>, IUserPasswordStore<ApplicationUser, int>
    {
        private IUserService userService;

        public ApplicationUserStore()
        {
            using (var resolver = new DependencyResolver())
            {
                userService = resolver.GetService(typeof(IUserService)) as IUserService;
            }
        }

        public Task CreateAsync(ApplicationUser user)
        {
            try
            {
                userService.Create(user.Name, user.UserName, user.PasswordHash);
            }
            catch (ArgumentException exception)
            {
                return Task.FromException(exception);
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            //consider implementing in BL?
            //userService.Delete(user.Id);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            return;
        }

        public Task<ApplicationUser> FindByIdAsync(int userId)
        {
            var user = userService.Find(userId);
            return Task.FromResult(user.ToAppUser());
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var user = userService.Find(userName);
            return Task.FromResult(user.ToAppUser());
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                return Task.FromResult(user.PasswordHash);

            var domainUser = userService.Find(user.Id);
            return Task.FromResult(domainUser?.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task.FromResult(true);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            if (user.Id != 0)
                userService.ChangePassword(user.Id, passwordHash);

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotSupportedException();
        }
    }
}