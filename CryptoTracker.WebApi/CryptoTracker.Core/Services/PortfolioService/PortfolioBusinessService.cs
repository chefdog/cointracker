using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Core.Models;
using CryptoTracker.Exceptions;

namespace CryptoTracker.Core.Services.PortfolioService
{
    public class PortfolioBusinessService : IBusinessService<PortfolioDataTransferModel>, IDisposable
    {
        private IRepository _repos;
        private IRepository _itemRepos;
        private IBusinessService<CoinDataTransferModel> _coinBusinessService;

        public PortfolioBusinessService(CTDbContext dbContext, IBusinessService<CoinDataTransferModel> coinBusinessService) {
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
                var portfolio = await _repos.GetAsync(model) as PortfolioModel;
                if (portfolio != null) {
                    throw new ValidationException("Entity already exist");
                }
                
                portfolio = await _repos.AddAsync(model) as PortfolioModel;
                result = portfolio.ToDto();
                result.Items = dto.Items;

                if (result.Items.Any())
                {
                    var items = result.Items.Select(i => i.ToModel()).ToList<IModel>();
                    await _itemRepos.AddRangeAsync(items);
                }
                return result;
            }
            catch (Exception ex) {
                Exceptions.ExceptionHandler.HandleBusinessServiceException(ex);
            }
            return result;
        }

        public async Task<PortfolioDataTransferModel> Find(PortfolioDataTransferModel dto)
        {
            PortfolioDataTransferModel result = new PortfolioDataTransferModel();
            try {
                var model = dto.ToModel();
                var portfolio = await _repos.GetAsync(model) as PortfolioModel;
                if(portfolio==null) Exceptions.ExceptionHandler.HandleBusinessServiceException("Portfolio could not be located based on the search parameters");
                return portfolio.ToDto();
            }
            catch (Exception ex)
            {
                Exceptions.ExceptionHandler.HandleBusinessServiceException(ex);
            }
            return result;
        }

        public Task<List<PortfolioDataTransferModel>> GetMany(int start, int skip, int max)
        {
            throw new NotImplementedException();
        }

        public Task<PortfolioDataTransferModel> Remove(PortfolioDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public async Task<PortfolioDataTransferModel> Update(PortfolioDataTransferModel dto)
        {
            try
            {
                var model = dto.ToModel();
                var portfolio = await _repos.GetAsync(model) as PortfolioModel;
                if (portfolio.Id == model.Id)
                {
                    if (dto.Items.Any())
                    {
                        var items = dto.Items.Select(i => i.ToModel()).ToList<IModel>();
                        await _itemRepos.AddRangeAsync(items);                        
                    }

                    model.LastModified = DateTime.Now;
                    await _repos.UpdateAsync(portfolio as IModel);
                    return dto;
                }
                ExceptionHandler.HandleBusinessServiceException("Not a valid portfolio");                
            }
            catch (ValidationException vex) {
                throw vex;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleBusinessServiceException(ex);
            }
            return dto;
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
