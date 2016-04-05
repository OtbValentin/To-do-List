using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel;
using AutoMapper.Mappers;
using AutoMapper;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFIntKeyGenericRepository<TModel, TEFModel> : IRepository<TModel, int>
        where TModel : IUnique<int>
        where TEFModel : class, IEntity<int>
    {
        protected readonly DbContext context;
        protected readonly IMapper mapper;

        public EFIntKeyGenericRepository(DbContext context, IMapper mapper)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            this.context = context;
            this.mapper = mapper;
        }

        public virtual void Create(TModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            TEFModel efEntity = mapper.Map<TEFModel>(entity);

            context.Set<TEFModel>().Add(efEntity);
        }

        public virtual void Delete(int key)
        {
            TEFModel efEntity = context.Set<TEFModel>().Find(key);

            if (efEntity != default(TEFModel))
            {
                context.Set<TEFModel>().Remove(efEntity);
            }
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return context.Set<TEFModel>().Select(efModel => mapper.Map<TModel>(efModel));
        }

        public virtual TModel Find(int key)
        {
            TEFModel entity = context.Set<TEFModel>().Find(key);

            if (entity == null)
            {
                return default(TModel);
            }

            return mapper.Map<TModel>(entity);
        }

        public virtual void Update(TModel entity)
        {
            if (entity != null)
            {
                context.Entry(mapper.Map<TEFModel>(entity)).State = EntityState.Modified;
            }
        }
    }
}
