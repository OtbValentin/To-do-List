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
                configuration.CreateMap<DB.Todo, Domain.Todo>().ConstructUsing((DB.Todo source) =>
                    new Domain.Todo(source.Id, null, source.Text, source.IsCompleted, source.Note));

                //configuration.CreateMap<DB.TodoList, Domain.TodoList>().ConstructUsing((DB.TodoList sourceList) =>
                //    new Domain.TodoList(sourceList.Id, )

                configuration.CreateMap<DB.TodoListCollection, Domain.TodoListCollection>().ConstructUsing((DB.TodoListCollection source) =>
                    new Domain.TodoListCollection(source.L))

            });

            Mapper = config.CreateMapper();
        }
    }
}
