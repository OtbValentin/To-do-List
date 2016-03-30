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
using Ninject.Web.Common;

namespace Epam.TodoManager.Infrastructure.DependencyInjection
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //BL
            Bind<IUserService>().To<UserService>().InRequestScope();
            Bind<ITodoService>().To<TodoService>().InRequestScope();
            Bind<ITodoListService>().To<TodoListService>().InRequestScope();

            //DA
            Bind<IUserRepository>().To<EFUserRepository>().InRequestScope();
            Bind<ITodoListCollectionRepository>().To<EFTodoListCollectionRepository>().InRequestScope();
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InRequestScope();
            Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();

            //Utils
            Bind<IMapper>().ToConstant(EntityMapper.Mapper);
        }
    }
}
