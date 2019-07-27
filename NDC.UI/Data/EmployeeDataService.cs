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
            //return await _employeeDA.GetAllAsync(new Employee());
            var it1 = new Employee { Id = new Guid(), Code="PJC", Name = "Paulo Costa", IsActive = true , DepartmentOfEmployee = new Department { Id = new Guid(), Description = "IT"} };
            var it2 = new Employee { Id = new Guid(), Code="LPC", Name = "Leonor Costa", IsActive = true, DepartmentOfEmployee = new Department { Id = new Guid(), Description = "Medical staff" } };
            var it3 = new Employee { Id = new Guid(), Code="OPC", Name = "Odete Costa" };
            var list = new List<Employee>();
            list.Add(it1);
            list.Add(it2);
            list.Add(it3);

            return list;
        }

        public async Task<bool> RemoveEmployeeAsync(Guid id)
        {
            return await _employeeDA.RemoveAsync(new Employee(), id);
        }
    }
}
