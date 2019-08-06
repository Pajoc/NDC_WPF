using NDC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public override async Task<bool> UpdateAsync(Employee emp)
        {
            var serializedEmployeeToUpdate = JsonConvert.SerializeObject(emp);

            var request = new HttpRequestMessage(HttpMethod.Put, emp.GetType().Name.ToLower() + "/" + emp.Id);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedEmployeeToUpdate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return true;
        }
        public override async Task<bool> InsertAsync(Employee emp)
        {
            var serializedEmployeeToInsert = JsonConvert.SerializeObject(emp);

            var request = new HttpRequestMessage(HttpMethod.Post, emp.GetType().Name.ToLower());

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedEmployeeToInsert);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return true;
        }
    }
}
