using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using CryptoTracker.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Core.Services.CoinService
{
    internal class CoinPriceRepository : IRepository
    {
        private CTDbContext _dbContext;
        public CoinPriceRepository(CTDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IModel> AddAsync(IModel entity)
        {
            try
            {
                if (entity == null) return null;
                var model = entity as CoinPriceModel;
                model.Created = DateTime.Now;
                model.LastModified = DateTime.Now;
                model.RowGuid = Guid.NewGuid();
                await _dbContext.Set<CoinPriceModel>().AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public async Task<List<IModel>> AddRangeAsync(List<IModel> data)
        {
            try
            {
                if (data.Any())
                {
                    var range = data.Cast<CoinPriceModel>();
                    _dbContext.Set<CoinPriceModel>().AddRange(range.AsEnumerable());
                    await _dbContext.SaveChangesAsync();
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public Task<IModel> DeleteAsync(IModel changes)
        {
            throw new NotImplementedException();
        }

        public Task<IModel> GetAsync(IModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IModel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IModel> GetMany(int pageSize, int pageNumber, object queryParam)
        {
            throw new NotImplementedException();
        }

        public Task<IModel> UpdateAsync(IModel changes)
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
        // ~CoinPriceRepository() {
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
