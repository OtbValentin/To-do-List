using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI.Repositories;
using DomainModel;
using System.Data.Entity;
using DataAccess.EntityFramework;

namespace DataAccess
{
    public class EFIntKeyGenericRepository<TModel, TEFModel> : IRepository<TModel, int>
        where TModel : IUnique<int>
        where TEFModel : class, IEntity<int>
    {
        protected readonly DbContext context;
        protected readonly IMapper<TModel, TEFModel> mapper;

        public EFIntKeyGenericRepository(DbContext context, IMapper<TModel, TEFModel> mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void Create(TModel entity)
        {
            TEFModel efEntity = mapper.Map(entity);

            context.Set<TEFModel>().Add(efEntity);
        }

        public void Delete(int key)
        {
            //boxing issue
            TEFModel efEntity = context.Set<TEFModel>().Find(key);

            if (efEntity != default(TEFModel))
            {
                context.Set<TEFModel>().Remove(efEntity);
            }
        }

        public IEnumerable<TModel> GetAll()
        {
            //deferred execution issue when exception arise
            return context.Set<TEFModel>().Select(efModel => mapper.ReverseMap(efModel));
        }

        public TModel GetByKey(int key)
        {
            return mapper.ReverseMap(context.Set<TEFModel>().Find(key));
        }

        public void Update(TModel entity)
        {
            context.Entry(mapper.Map(entity)).State = EntityState.Modified;
        }
    }
}
