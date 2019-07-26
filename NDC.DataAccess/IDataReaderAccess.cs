using NDC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDC.DataAccess
{
    public interface IDataReaderAccess<T>
    {
        Task<IEnumerable<T>> GetAllAsync(T entity);
        
    }
}
