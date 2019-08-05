using System;
using System.Threading.Tasks;

namespace NDC.DataAccess
{
    public interface IDataAccess<T>: IDataReaderAccess<T>
    {
        Task<bool> RemoveAsync(T entity, Guid guid);
        Task<bool> UpdateAsync(T entity);
        
    }
}