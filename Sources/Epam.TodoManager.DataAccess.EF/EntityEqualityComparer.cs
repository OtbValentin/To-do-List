using Epam.TodoManager.DataAccess.EF.Model;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.EF
{
    public class IntKeyEntityEqualityComparer<TEntity> : IEqualityComparer<TEntity> where TEntity : IEntity<int>
    {
        public bool Equals(TEntity x, TEntity y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(TEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
