using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Statistics")]
    public class StatisticsController : Controller
    {
        private List<StatisticsDataTransfertModel> _data;

        public StatisticsController() {
            _data = new List<StatisticsDataTransfertModel>
            {
                new StatisticsDataTransfertModel { Id = 1, Amount = 300, Currency = "ETH", Icon = "", Title = "Etheruem", Total = 10 },
                new StatisticsDataTransfertModel { Id = 2, Amount = 6000, Currency = "BTC", Icon = "", Title = "Bitcoin", Total = 4 },
                new StatisticsDataTransfertModel { Id = 3, Amount = 300, Currency = "XLM", Icon = "", Title = "Stellar", Total = 1000 },
            };
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<StatisticsDataTransfertModel> Get()
        {
            return _data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public StatisticsDataTransfertModel Get(int id)
        {
            return _data.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class StatisticsDataTransfertModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int Total { get; set; }
        public string Icon { get; set; }
    }
}