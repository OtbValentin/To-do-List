﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.TodoManager.Infrastructure.EntityMapping;
using Domain = Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.Tests
{
    [TestClass]
    public class EntityMapperTest
    {
        [TestMethod]
        public void DbTodoListCollectionToDomainTodoListCollectionIdMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            int id = 10;
            DB.TodoListCollection db = new DB.TodoListCollection() { Id = id };

            Domain.TodoListCollection domain = mapper.Map<Domain.TodoListCollection>(db);

            Assert.AreEqual(true, AreCollectionsEqual(db, domain));
        }

        [TestMethod]
        public void DbTodoListCollectionToDomainTodoListCollectionUserIdMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            int userId = 130;
            DB.TodoListCollection db = new DB.TodoListCollection() { UserId = userId };

            Domain.TodoListCollection domain = mapper.Map<Domain.TodoListCollection>(db);

            Assert.AreEqual(true, AreCollectionsEqual(db, domain));
        }

        [TestMethod]
        public void DbTodoListCollectionToDomainTodoListCollectionListsMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            List<DB.TodoList> lists = new List<DB.TodoList>();
            List<DB.Todo> todos = new List<DB.Todo>();
            todos.Add(new DB.Todo()
            {
                Id = 33,
                DueDate = DateTime.Now,
                IsCompleted = true,
                Note = "Urgent",
                Text = "Finish the project"
            });

            lists.Add(new DB.TodoList() { Id = 124, Title = "March todos", Todos = todos });
            lists.Add(new DB.TodoList() { Id = 135, Title = "Weekly todos" });

            DB.TodoListCollection db = new DB.TodoListCollection() { Lists = lists };

            Domain.TodoListCollection domain = mapper.Map<Domain.TodoListCollection>(db);

            Assert.AreEqual(true, AreCollectionsEqual(db, domain));
        }

        private bool AreCollectionsEqual(DB.TodoListCollection db, Domain.TodoListCollection domain)
        {
            if ((db.Id != domain.Id) || (db.UserId != domain.UserId))
            {
                return false;
            }

            IEnumerator<Domain.TodoList> enumerator = domain.GetEnumerator();
            foreach (var dbList in db.Lists)
            {
                enumerator.MoveNext();

                Domain.TodoList list = enumerator.Current;


                if (!AreListsEqual(dbList, list))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreListsEqual(DB.TodoList db, Domain.TodoList domain)
        {
            if (db.Id != domain.Id || db.Title != domain.Title ||
                    db.Todos.Count != domain.TodoItems.Count())
            {
                return false;
            }

            IEnumerator<Domain.Todo> enumerator = domain.GetEnumerator();
            foreach (var dbTodo in db.Todos)
            {
                enumerator.MoveNext();

                Domain.Todo todo = enumerator.Current;

                if (!AreTodosEqual(dbTodo, todo))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreTodosEqual(DB.Todo db, Domain.Todo domain)
        {
            return (db.DueDate == domain.DueDate) && (db.Id == domain.Id) &&
                 (db.IsCompleted == domain.IsCompleted) && (db.Note == domain.Note) &&
                 (db.Text == domain.Text);
        }
    }
}
