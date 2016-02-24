using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;
using EF = DataAccess.EntityFramework;

namespace DataAccess
{
    public class UserMapper : IMapper<EF.User, User>
    {
        private readonly IMapper<EF.Role, Role> roleMapper;
        private readonly IMapper<EF.TodoList, TodoList> listMapper;

        public UserMapper(IMapper<EF.Role, Role> roleMapper, IMapper<EF.TodoList, TodoList> listMapper)
        {
            this.roleMapper = roleMapper;
            this.listMapper = listMapper;
        }

        public User Map(EF.User entity)
        {
            return new User(entity.Id)
            {
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                Roles = entity.Roles.Select(efRole => roleMapper.Map(efRole)),
                TodoLists = entity.Lists.Select(efList => listMapper.Map(efList))
            };
        }

        public EF.User ReverseMap(User entity)
        {
            return new EF.User()
            {
                Id = entity.Id,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                Roles = entity.Roles.Select(role => roleMapper.ReverseMap(role)).ToList(),
                Lists = entity.TodoLists.Select(list => listMapper.ReverseMap(list)).ToList()
            };
        }
    }

    public class RoleMapper : IMapper<EF.Role, Role>
    {
        public Role Map(EF.Role entity)
        {
            return new Role(entity.Id)
            {
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public EF.Role ReverseMap(Role entity)
        {
            return new EF.Role()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Name
            };
        }
    }

    public class TodoListMapper : IMapper<EF.TodoList, TodoList>
    {
        private readonly IMapper<EF.Todo, Todo> todoMapper;

        public TodoListMapper(IMapper<EF.Todo, Todo> todoMapper)
        {
            this.todoMapper = todoMapper;
        }

        public TodoList Map(EF.TodoList entity)
        {
            return new TodoList(entity.Id)
            {
                Title = entity.Title,
                DueDate = entity.DueDate,
                Todos = entity.Todos.Select(efTodo => todoMapper.Map(efTodo))
            };
        }

        public EF.TodoList ReverseMap(TodoList entity)
        {
            return new EF.TodoList()
            {
                Id = entity.Id,
                DueDate = entity.DueDate,
                Title = entity.Title,
                Todos = entity.Todos.Select(todo => todoMapper.ReverseMap(todo)).ToList()
            };
        }
    }

    public class TodoMapper : IMapper<EF.Todo, Todo>
    {
        public Todo Map(EF.Todo entity)
        {
            return new Todo(entity.Id)
            {
                IsCompleted = entity.IsCompleted,
                Text = entity.Text
            };
        }

        public EF.Todo ReverseMap(Todo entity)
        {
            return new EF.Todo()
            {
                Id = entity.Id,
                IsCompleted = entity.IsCompleted,
                Text = entity.Text
            };
        }
    }
}
