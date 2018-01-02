using CryptoTracker.Common.Interfaces;
using CryptoTracker.DataAccess.Models;
using CryptoTracker.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.Repositories
{
    public class ExchangeRepository : IRepository
    {
        private string _baseAddress;
        private string _api;
        private List<string> _queryParams;
        public ExchangeRepository(string baseAddress, string api, List<string> queryParams) {
            _baseAddress = baseAddress;
            _api = api;
            _queryParams = queryParams;
        }

        public Task<IModel> AddAsync(IModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IModel> DeleteAsync(IModel changes)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IModel> GetAsync(IModel entity)
        {
            throw new NotImplementedException();
        }
               

        public IQueryable<IModel> GetMany(int pageSize, int pageNumber, string name)
        {
            IQueryable<ExchangeModel> result = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    HttpResponseMessage response = client.GetAsync(_api).Result;
                    var stringData = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<IQueryable<ExchangeModel>>(stringData);
                }
                return result;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return result;
        }

        public Task<IModel> UpdateAsync(IModel changes)
        {
            throw new NotImplementedException();
        }
    }
}
