using NDC.DataAccess;
using NDC.Model;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NDC.UI.Data
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private IDataAccess<Employee> _employeeDA;

        public EmployeeDataService(IDataAccess<Employee> employeeDA)
        {
            _employeeDA = employeeDA;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeDA.GetAllAsync(new Employee());
        }

        public async Task<bool> RemoveEmployeeAsync(Guid id)
        {
            return await _employeeDA.RemoveAsync(new Employee(), id);
        }
    }
}
