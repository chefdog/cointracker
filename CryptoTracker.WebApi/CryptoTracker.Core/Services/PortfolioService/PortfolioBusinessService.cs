using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Core.Models;


namespace CryptoTracker.Core.Services.PortfolioService
{
    public class PortfolioBusinessService : IBusinessService<PortfolioDataTransferModel>, IDisposable
    {
        private IRepository _repos;
        private IRepository _itemRepos;
        private IBusinessService<CoinDataTransferModel> _coinBusinessService;
        

        public PortfolioBusinessService(AppSettings appSettings, CTDbContext dbContext, IBusinessService<CoinDataTransferModel> coinBusinessService) {
            _repos = new PortfolioRepository(dbContext);
            _itemRepos = new PortfolioItemRepository(dbContext);
            _coinBusinessService = coinBusinessService;
        }

        public async Task<PortfolioDataTransferModel> Create(PortfolioDataTransferModel dto)
        {
            PortfolioDataTransferModel result = new PortfolioDataTransferModel();
            try
            {
                var model = dto.ToModel();
                await _repos.AddAsync(model);

                var remoteData = _coinBusinessService.GetMany(0, 0, 1000);
                var data = from c in remoteData.Result
                    from i in dto.Items
                    where c.Tag.Equals(i.CoinTag)
                    select _itemRepos.AddAsync(i.ToModel());
                
            }
            catch (Exception ex) {
                Exceptions.ExceptionHandler.HandleBusinessServiceException(ex);
            }
            return result;
        }

        public Task<PortfolioDataTransferModel> Find(PortfolioDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<PortfolioDataTransferModel>> GetMany(int start, int skip, int max)
        {
            throw new NotImplementedException();
        }

        public Task<PortfolioDataTransferModel> Remove(PortfolioDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<PortfolioDataTransferModel> Update(PortfolioDataTransferModel dto)
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
                    _repos.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PortfolioBusinessService() {
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
