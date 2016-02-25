using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DataAccessAPI.Repositories
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
