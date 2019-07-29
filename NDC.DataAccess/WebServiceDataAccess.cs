using NDC.DataAccess;
using NDC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NDC.DataAccess
{
    public class WebServiceDataAccess<T> : IDataAccess<T>
        where T : class
    {
        //WebClient _client = new WebClient() { Encoding = Encoding.UTF8 };
        //readonly string _baseUri = "http://localhost:4070/api/";

        //public IEnumerable<T> GetAll(T entity)
        //{
        //    var Uri = _baseUri + entity.GetType().Name.ToLower();
        //    string result = _client.DownloadString(Uri);
        //    var returnedData = JsonConvert.DeserializeObject <IEnumerable<T>>(result);
        //    return returnedData;
        //}

        //public bool Remove(T entity,Guid guid)
        //{
        //    var uri = _baseUri + entity.GetType().Name.ToLower()+"/"+ guid;
        //    byte[] dataBytes2 = Encoding.UTF8.GetBytes("");
        //    byte[] responseBytes = _client.UploadData(new Uri(uri), "DELETE", dataBytes2);
        //    return true;
        //}

        HttpClient _httpClient = new HttpClient();

        public WebServiceDataAccess()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:4070/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        public async Task<IEnumerable<T>> GetAllAsync(T entity )
        {

            string pmts = "Code,LSI";
            var response = await _httpClient.GetAsync(entity.GetType().Name.ToLower()+"/"+ pmts);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            var returnedData = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            return returnedData;
        }

        public async Task<bool> RemoveAsync(T entity, Guid guid)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, entity.GetType().Name.ToLower() + "/" + guid);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return true;
        }

    }
}
