using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoTracker.Core.Services.HistoryService;

namespace CryptoTracker.Core.Services.CoinService
{
    public class CoinBusinessService : IBusinessService<CoinDataTransferModel>, IDisposable
    {
        #region fields
        private AppSettings _appSettings;
        private IRepository _exchangeRepos;
        private IRepository _coinRepos;
        private IBusinessService<HistoryLogDataTransferModel> _historyService;
        #endregion
        public CoinBusinessService(AppSettings appSettings, 
            CTDbContext dbContext, IBusinessService<HistoryLogDataTransferModel> historyService) {
            _exchangeRepos = new ExchangeRepository(appSettings.CoinMarketCap.BaseAddress, appSettings.CoinMarketCap.Api, appSettings.CoinMarketCap.QueryParams);
            _coinRepos = new CoinRepository(dbContext);
            _historyService = historyService;
            _appSettings = appSettings;
        }

        public Task<CoinDataTransferModel> Create(CoinDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<CoinDataTransferModel> Find(CoinDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CoinDataTransferModel>> GetMany(int start, int skip, int max)
        {
            List<CoinDataTransferModel> result = new List<CoinDataTransferModel>();
            try
            {
                //1 get info on latest request
                var historyData = await _historyService.GetMany(0, 0, 100);
                //2 if latest request is within range, proceed with database call
                if (historyData.Any())
                {
                    historyData = historyData.OrderByDescending(x => x.LastModified).ToList();
                    var query = from h in historyData
                        where h.LastModified.AddSeconds(_appSettings.CoinMarketCap.RefreshInterval) < DateTime.Now
                        select h;
                    if (query.Any())
                    {
                        var remoteData =_exchangeRepos.GetMany(1000, 0, string.Empty);
                        
                    }
                }
                //3 if latest request is outside range, fetch from remote api and proceed with database update or add.
            }
            catch (RepositoryException rex) {
                ExceptionHandler.ProcessRepositoryException(rex);
            }
            return result;
        }

        public Task<CoinDataTransferModel> Remove(CoinDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<CoinDataTransferModel> Update(CoinDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CoinBusinessService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
