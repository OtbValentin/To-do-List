using DependencyInjection = Epam.TodoManager.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Epam.TodoManager.Presentation.WebApi.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private static DependencyInjection.IDependencyResolver resolver
            = new DependencyInjection.NinjectResolver();

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return resolver.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolver.GetAll(serviceType);
        }
    }
}