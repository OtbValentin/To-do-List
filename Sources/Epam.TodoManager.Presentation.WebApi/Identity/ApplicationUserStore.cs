﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Epam.TodoManager.BusinessLogic.UserService;
using Epam.TodoManager.BusinessLogic.RoleService;
using Mock = Epam.TodoManager.BusinessLogic.Mock;
using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.Presentation.WebApi.Identity
{
    //TODO: implement additional interfaces (IXxxStore) if necessary
    //      reimplement mapping
    public class ApplicationUserStore : IUserStore<ApplicationUser, int>, IUserPasswordStore<ApplicationUser, int>
    {
        private IUserService userService;
        private IRoleService roleService;

        public ApplicationUserStore()
        {
            userService = new Mock.UserService();
            roleService = new Mock.RoleService();
        }

        public Task CreateAsync(ApplicationUser user)
        {
            userService.Create(user.UserName, user.PasswordHash);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            userService.Delete(user.Id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            return;
        }

        public Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return Task.FromResult(ToApplicationUser(userService.Find(userId)));
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(ToApplicationUser(userService.Find(userName)));
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
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        private static User ToDomainUser(ApplicationUser appUser)
        {
            if (appUser == null)
                return null;

            return new User(appUser.Id, appUser.UserName, appUser.PasswordHash, null, null);
        }

        private static ApplicationUser ToApplicationUser(User domainUser)
        {
            if (domainUser == null)
                return null;

            return new ApplicationUser()
            {
                Id = domainUser.Id,
                UserName = domainUser.Email,
                PasswordHash = domainUser.PasswordHash
            };
        }
    }
}