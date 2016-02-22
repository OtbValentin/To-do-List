using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAPI
{
    public interface IRepository<TEntity, TKey> where TEntity : IUnique<TKey>
    {
        void Create(TEntity entity);
        TEntity GetByKey(TKey key);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TKey key);
    }
}
