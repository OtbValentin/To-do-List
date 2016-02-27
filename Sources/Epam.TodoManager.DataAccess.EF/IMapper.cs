using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DataAccess.EF
{
    public interface IMapper<TModel, TEFModel>
    {
        TEFModel Map(TModel entity);
        TModel ReverseMap(TEFModel entity);
    }
}
