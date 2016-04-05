using Ninject;
using System;
using System.Collections.Generic;

namespace Epam.TodoManager.Infrastructure.DependencyInjection
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver()
        {
            kernel = new StandardKernel(new NinjectModule());
        }

        public void Dispose()
        {
            kernel.Dispose();
        }

        public object Get(Type objectType)
        {
            return kernel.TryGet(objectType);
        }

        public IEnumerable<object> GetAll(Type objectType)
        {
            return kernel.GetAll(objectType);
        }
    }
}
