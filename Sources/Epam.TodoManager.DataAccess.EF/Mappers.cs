using System.Linq;
using Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;

namespace Epam.TodoManager.DataAccess.EF
{
    public class UserMapper : IMapper<User, DB.User>
    {
        private readonly IMapper<Role, DB.Role> roleMapper;
        private readonly IMapper<TodoList, DB.TodoList> listMapper;

        public UserMapper(IMapper<Role, DB.Role> roleMapper, IMapper<TodoList, DB.TodoList> listMapper)
        {
            this.roleMapper = roleMapper;
            this.listMapper = listMapper;
        }

        public User ReverseMap(DB.User entity)
        {
            return new User(entity.Id)
            {
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                Roles = entity.Roles.Select(efRole => roleMapper.ReverseMap(efRole)),
                TodoLists = entity.Lists.Select(efList => listMapper.ReverseMap(efList))
            };
        }

        public DB.User Map(User entity)
        {
            return new DB.User()
            {
                Id = entity.Id,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                Roles = entity.Roles.Select(role => roleMapper.Map(role)).ToList(),
                Lists = entity.TodoLists.Select(list => listMapper.Map(list)).ToList()
            };
        }
    }

    public class RoleMapper : IMapper<Role, DB.Role>
    {
        public Role ReverseMap(DB.Role entity)
        {
            return new Role(entity.Id)
            {
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public DB.Role Map(Role entity)
        {
            return new DB.Role()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Name
            };
        }
    }

    public class TodoListMapper : IMapper<TodoList, DB.TodoList>
    {
        private readonly IMapper<Todo, DB.Todo> todoMapper;

        public TodoListMapper(IMapper<Todo, DB.Todo> todoMapper)
        {
            this.todoMapper = todoMapper;
        }

        public TodoList ReverseMap(DB.TodoList entity)
        {
            return new TodoList(entity.Id)
            {
                UserId = entity.UserId,
                Title = entity.Title,
                DueDate = entity.DueDate,
                Todos = entity.Todos.Select(efTodo => todoMapper.ReverseMap(efTodo))
            };
        }

        public DB.TodoList Map(TodoList entity)
        {
            return new DB.TodoList()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Title = entity.Title,
                DueDate = entity.DueDate,
                Todos = entity.Todos.Select(todo => todoMapper.Map(todo)).ToList()
            };
        }
    }

    public class TodoMapper : IMapper<Todo, DB.Todo>
    {
        public Todo ReverseMap(DB.Todo entity)
        {
            return new Todo(entity.Id)
            {
                ListId = entity.ListId,
                IsCompleted = entity.IsCompleted,
                Text = entity.Text
            };
        }

        public DB.Todo Map(Todo entity)
        {
            return new DB.Todo()
            {
                Id = entity.Id,
                ListId = entity.ListId,
                IsCompleted = entity.IsCompleted,
                Text = entity.Text
            };
        }
    }
}
