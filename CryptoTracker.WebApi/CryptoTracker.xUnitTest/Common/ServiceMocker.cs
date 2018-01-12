using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Core.ModelMappers;
using CryptoTracker.Core.Services.CoinService;
using CryptoTracker.Core.Services.HistoryService;
using CryptoTracker.Core.Services.PortfolioService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.xUnitTest.Common
{
    public class ServiceMocker
    {
        private static string _connectionstring = "Server=(localdb)\\mssqllocaldb;Database=CtDb;Trusted_Connection=True;";
        private IOptions<AppSettings> _settings;
        private CTDbContext _dbContext;
        private IBusinessService<HistoryLogDataTransferModel> _historyBusinessService;

        public ServiceMocker() {
            _settings = Options.Create(new AppSettings
            {
                ConnectionString = _connectionstring,
                CoinMarketCap = new CoinMarketCap {
                    BaseAddress = "https://api.coinmarketcap.com",
                    Api = "/v1/ticker",
                    QueryParams = new List<string> { "limit=10"} }
            });

            _dbContext = new CTDbContext(_settings, new CryptoTrackerEntityMapper());
            _historyBusinessService = new HistoryBusinessService(_settings.Value, _dbContext);
        }

        public IBusinessService<CoinDataTransferModel> GetCoinService()
        {
            return new CoinBusinessService(_settings.Value, _dbContext, _historyBusinessService);
        }

        public IBusinessService<PortfolioDataTransferModel> GetPortfolioService()
        {
            var coinService = GetCoinService();
            return new PortfolioBusinessService(_settings.Value, _dbContext, coinService);
        }

        public IBusinessService<HistoryLogDataTransferModel> GetHistoryLogRepository()
        {
            return _historyBusinessService;
        }
    }
}
