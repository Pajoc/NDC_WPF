using NDC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NDC.DataAccess
{
    public class EmployeeWServDataAccess: WebServiceDataAccess<Employee>
    {
       public override async Task<IEnumerable<Employee>> GetAllAsync(Employee emp)

        {
            var filter = "?";
            string pmts = "/GetAll";
            filter = emp.Code != null ? filter + $"Code={emp.Code}" : filter;
            
            if (emp.Name != null)
            {
                filter = filter != "?" ? filter + $"&Name={emp.Name}" : filter + $"Name={emp.Name}";
            }

            pmts = filter != "?" ? pmts + filter : pmts;

            var response = await _httpClient.GetAsync(emp.GetType().Name.ToLower() + pmts);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var returnedData = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);
            return returnedData;
        }



          
    }
}
