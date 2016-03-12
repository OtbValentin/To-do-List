using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain = Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DomainModel;
namespace Epam.TodoManager.Infrastructure.EntityMapping
{
    public static class EntityMapper
    {
        public static IMapper Mapper { get; private set; }

        static EntityMapper()
        {
            var config = new MapperConfiguration(configuration =>
            {
                // EF -> Domain
                configuration.CreateMap<DB.User, Domain.User>().ConvertUsing((DB.User dbUser) =>
                    new Domain.User(dbUser.Id, dbUser.ListCollectionId, dbUser.Email, dbUser.PasswordHash,
                    new Domain.UserProfile(dbUser.Profile.Id, dbUser.Profile.Name, dbUser.Profile.RegisterDate)));

                configuration.CreateMap<DB.TodoListCollection, Domain.TodoListCollection>().ConvertUsing((DB.TodoListCollection dbCollection) =>
                {
                    return new Domain.TodoListCollection(dbCollection.Id, dbCollection.UserId, dbCollection.Lists.Select(dbList =>
                    {
                        return new Domain.TodoList(dbList.Id, dbList.Title, dbList.Todos.Select(dbTodo =>
                            new Domain.Todo(dbTodo.Id, dbTodo.Text, dbTodo.IsCompleted, dbTodo.Note, dbTodo.DueDate)));
                    }));
                });

                // Domain -> EF
                configuration.CreateMap<Domain.User, DB.User>().ConvertUsing((Domain.User domainUser) =>
                    new DB.User()
                    {
                        Id = domainUser.Id,
                        PasswordHash = domainUser.PasswordHash,
                        Email = domainUser.Email,
                        ProfileId = domainUser.Profile.Id,
                        Profile = new DB.UserProfile() { Id = domainUser.Profile.Id, Name = domainUser.Profile.Name, RegisterDate = domainUser.Profile.RegisterDate },
                        ListCollectionId = domainUser.Id
                    });

                configuration.CreateMap<Domain.TodoListCollection, DB.TodoListCollection>().ConvertUsing((Domain.TodoListCollection collection) =>
                {
                    DB.TodoListCollection dbCollection = new DB.TodoListCollection()
                    {
                        Id = collection.Id,
                        UserId = collection.UserId
                    };

                    dbCollection.Lists = collection.Select(list =>
                    {
                        DB.TodoList dbList = new DB.TodoList()
                        {
                            Id = list.Id,
                            Title = list.Title,
                            ListCollectionId = dbCollection.Id,
                            ListCollection = dbCollection
                        };

                        dbList.Todos = list.Select(todo => new DB.Todo()
                        {
                            Id = todo.Id,
                            DueDate = todo.DueDate,
                            IsCompleted = todo.IsCompleted,
                            List = dbList,
                            ListId = dbList.Id,
                            Note = todo.Note,
                            Text = todo.Text
                        }).ToList();

                    return dbList;
                    }).ToList();

                    return dbCollection;
                });
            });

            Mapper = config.CreateMapper();
        }
    }
}