using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using CryptoTracker.Exceptions;
using Newtonsoft.Json;

namespace CryptoTracker.Core.Services.CoinService
{
    internal class ExchangeRepository : IRepository
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

        public Task<List<IModel>> AddRangeAsync(List<IModel> data)
        {
            throw new NotImplementedException();
        }

        public Task<IModel> DeleteAsync(IModel changes)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _baseAddress = string.Empty;
            _api = string.Empty;
            _queryParams = null;
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
                    var data = JsonConvert.DeserializeObject<List<ExchangeModel>>(stringData);
                    result = data.AsQueryable<ExchangeModel>();
                }
                return result.Cast<IModel>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public Task<IModel> UpdateAsync(IModel changes)
        {
            throw new NotImplementedException();
        }
    }
}
