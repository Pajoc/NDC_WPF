using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NDC.Model;
using NDC.UI.Wrapper;

namespace NDC.UI.Data
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllAsync(Employee filter);
        Task<bool> RemoveEmployeeAsync(Guid id);
        Task<bool> UpdateEmployeeAsync(EmployeesWrapper emp);
        Task<bool> InsertEmployeeAsync(EmployeesWrapper emp);
    }
}