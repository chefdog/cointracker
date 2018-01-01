using CryptoTracker.DataAccess.Models;
using CryptoTracker.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.Repositories
{
    public class HttpJsonRepository
    {
        private string _baseAddress;
        public HttpJsonRepository(string baseAddress) {
            _baseAddress = baseAddress;
        }
        public async Task<List<ExchangeModel>> GetMany(string api, List<string> queryParams) {
            List<ExchangeModel> result = new List<ExchangeModel>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    HttpResponseMessage response = client.GetAsync(api).Result;
                    var stringData = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<ExchangeModel>>(stringData);
                }
                return result;
            }
            catch (Exception ex) {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return result;
        }

        
    }
}
