using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NDC.Model;

namespace NDC.UI.Data
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<bool> RemoveEmployeeAsync(Guid id);
    }
}