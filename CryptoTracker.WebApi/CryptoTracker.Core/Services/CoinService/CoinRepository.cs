using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using CryptoTracker.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Core.Services.CoinService
{
    internal class CoinRepository : IRepository
    {
        private CTDbContext _dbContext;
        public CoinRepository(CTDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<IModel> AddAsync(IModel entity)
        {
            try
            {
                var model = entity as CoinModel;
                model.Created = DateTime.Now;
                model.LastModified = DateTime.Now;
                model.RowGuid = Guid.NewGuid();
                await _dbContext.Set<CoinModel>().AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex) {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public async Task<IModel> DeleteAsync(IModel changes)
        {
            try
            {
                var model = changes as CoinModel;
                _dbContext.Remove<CoinModel>(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public async Task<IModel> GetAsync(IModel entity)
        {
            try
            {
                var model = entity as CoinModel;
                var result = await _dbContext.Set<CoinModel>().FindAsync(model.Id);                
                return result;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public IQueryable<IModel> GetMany(int pageSize, int pageNumber, string name)
        {
            try
            {
                var result = _dbContext.Set<CoinModel>().Take(pageSize);
                return result;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
        }

        public async Task<IModel> UpdateAsync(IModel entity)
        {
            try
            {
                var model = entity as CoinModel;
                model.LastModified = DateTime.Now;
                _dbContext.Set<CoinModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return null;
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
        // ~CoinRepository() {
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
