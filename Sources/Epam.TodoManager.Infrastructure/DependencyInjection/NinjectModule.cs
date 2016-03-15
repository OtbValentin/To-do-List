using Epam.TodoManager.BusinessLogic.TodoListService;
using Epam.TodoManager.BusinessLogic.TodoService;
using Epam.TodoManager.BusinessLogic.UserService;
using Epam.TodoManager.DataAccess.EF;
using Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DataAccess.EF.Repositories;
using Epam.TodoManager.DataAccess.Interface;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.Infrastructure.EntityMapping;
using System.Data.Entity;
using AutoMapper;

namespace Epam.TodoManager.Infrastructure.DependencyInjection
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //BL
            Bind<IUserService>().To<UserService>();
            Bind<ITodoService>().To<TodoService>();
            Bind<ITodoListService>().To<TodoListService>();

            //DA
            Bind<IUserRepository>().To<EFUserRepository>();
            Bind<ITodoListCollectionRepository>().To<EFTodoListCollectionRepository>();
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
            Bind<DbContext>().To<ApplicationDbContext>();

            //Utils
            Bind<IMapper>().ToConstant(EntityMapper.Mapper);
        }
    }
}
