using System;
using System.Collections.Generic;

namespace Epam.TodoManager.Infrastructure.DependencyInjection
{
    public interface IDependencyResolver : IDisposable
    {
        object Get(Type objectType);
        IEnumerable<object> GetAll(Type objectType);
    }
}
