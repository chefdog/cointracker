using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTracker.Core.Services.CoinService
{
    public class CoinBusinessService : IBusinessService<CoinDataTransferModel>, IDisposable
    {
        private IRepository _exchangeRepos;
        private IRepository _coinRepos;

        public CoinBusinessService(AppSettings appSettings, CTDbContext dbContext) {
            _exchangeRepos = new ExchangeRepository(appSettings.CoinMarketCap.BaseAddress, appSettings.CoinMarketCap.Api, appSettings.CoinMarketCap.QueryParams);
            _coinRepos = new CoinRepository(dbContext);
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
                //2 if latest request is within range, proceed with database call
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
