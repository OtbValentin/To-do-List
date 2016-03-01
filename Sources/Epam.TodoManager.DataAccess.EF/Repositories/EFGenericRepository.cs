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

        public EFIntKeyGenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        public void Create(TModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            TEFModel efEntity = Mapper.Map<TEFModel>(entity);

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
            return context.Set<TEFModel>().Select(efModel => Mapper.Map<TModel>(efModel));
        }

        public TModel Find(int key)
        {
            TEFModel entity = context.Set<TEFModel>().Find(key);

            if (entity == null)
            {
                return default(TModel);
            }

            return Mapper.Map<TModel>(entity);
        }

        public void Update(TModel entity)
        {
            if (entity != null)
            {
                context.Entry(Mapper.Map<TEFModel>(entity)).State = EntityState.Modified;
                //context.Entry(mapper.Map(entity)).State = EntityState.Modified;
            }
        }
    }
}
