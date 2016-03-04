using Epam.TodoManager.DataAccess.Interface;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using System.Data.Entity;

namespace Epam.TodoManager.DataAccess.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool isDisposed;

        private DbContext context;

        public IUserRepository UserRepository { get; private set; }

        public ITodoListCollectionRepository ListRepository { get; private set; }

        // Inject a context as a constructor param to repositories
        public EFUnitOfWork(DbContext context, IUserRepository userRepository, ITodoListCollectionRepository listRepository)
        {
            this.context = context;
            UserRepository = userRepository;
            ListRepository = listRepository;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                context.Dispose();
                isDisposed = true;
            }
        }
    }
}
