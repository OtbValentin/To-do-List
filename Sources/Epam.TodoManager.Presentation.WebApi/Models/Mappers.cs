using Domain = Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.Presentation.WebApi.Identity;
using System.Linq;

namespace Epam.TodoManager.Presentation.WebApi.Models
{
    public static class Mappers
    {
        public static User ToApiModel(this Domain.User domainUser)
        {
            return (domainUser == null) ? null : new User()
            {
                Id = domainUser.Id,
                Email = domainUser.Email,
                Name = domainUser.Profile?.Name
            };
        }

        public static User ToApiModel(this ApplicationUser appUser)
        {
            return (appUser == null) ? null : new User()
            {
                Id = appUser.Id,
                Name = appUser.UserName,
                Email = appUser.Name
            };
        }

        public static ApplicationUser ToAppUser(this NewUser newUser)
        {
            return (newUser == null) ? null : new ApplicationUser()
            {
                Name = newUser.Email,
                UserName = newUser.Name
            };
        }

        public static ApplicationUser ToAppUser(this Domain.User domainUser)
        {
            return (domainUser == null) ? null : new ApplicationUser()
            {
                Id = domainUser.Id,
                Name = domainUser.Email,
                PasswordHash = domainUser.PasswordHash,
                UserName = domainUser?.Profile.Name
            };
        }

        public static TodoItem ToApiModel(this Domain.Todo domainTodo)
        {
            return (domainTodo == null) ? null : new TodoItem()
            {
                Id = domainTodo.Id,
                Text = domainTodo.Text,
                Note = domainTodo.Note,
                DueDate = domainTodo.DueDate,
                IsCompleted = domainTodo.IsCompleted
                //List = domainTodo.List?.Id
            };
        }

        public static TodoList ToApiModel(this Domain.TodoList domainList)
        {
            return (domainList == null) ? null : new TodoList()
            {
                Id = domainList.Id,
                Title = domainList.Title,
                TodoItems = domainList.Select(item => item.Id).ToList()
            };
        }
    }
}