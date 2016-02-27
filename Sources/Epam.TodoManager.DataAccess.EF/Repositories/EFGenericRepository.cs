using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFIntKeyGenericRepository<TModel, TEFModel> : IRepository<TModel, int>
        where TModel : IUnique<int>
        where TEFModel : class, IEntity<int>
    {
        protected readonly DbContext context;
        protected readonly IMapper<TModel, TEFModel> mapper;

        public EFIntKeyGenericRepository(DbContext context, IMapper<TModel, TEFModel> mapper)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this.mapper = mapper;
            this.context = context;
        }

        public void Create(TModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            TEFModel efEntity = mapper.Map(entity);

            context.Set<TEFModel>().Add(efEntity);
        }

        public void Delete(int key)
        {
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

        public TModel Find(int key)
        {
            TEFModel entity = context.Set<TEFModel>().Find(key);

            if (entity == null)
            {
                return default(TModel);
            }

            return mapper.ReverseMap(entity);
        }

        public void Update(TModel entity)
        {
            if (entity != null)
            {
                context.Entry(mapper.Map(entity)).State = EntityState.Modified;
            }
        }
    }
}
