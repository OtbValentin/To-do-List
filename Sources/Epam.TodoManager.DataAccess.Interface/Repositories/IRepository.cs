using System.Collections.Generic;
using Epam.TodoManager.DomainModel;

namespace Epam.TodoManager.DataAccess.Interface.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : IUnique<TKey>
    {
        void Create(TEntity entity);
        TEntity Find(TKey key);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TKey key);
    }
}
