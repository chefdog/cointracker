using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using CryptoTracker.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Core.Services.PortfolioService
{
    internal class PortfolioRepository : IRepository
    {
        private CTDbContext _dbContext;
        public PortfolioRepository(CTDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IModel> AddAsync(IModel entity)
        {
            try
            {
                PortfolioModel model = entity as PortfolioModel;
                model.Created = DateTime.Now;
                model.LastModified = DateTime.Now;
                model.RowGuid = Guid.NewGuid();
                await _dbContext.Set<PortfolioModel>().AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return model as IModel;
            }
            catch (Exception ex) {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return entity;
        }

        public async Task<IModel> DeleteAsync(IModel entity)
        {
            try
            {
                PortfolioModel model = entity as PortfolioModel;
                _dbContext.Set<PortfolioModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return model as IModel;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return entity;
        }

        public async Task<IModel> GetByIdAsync(Int64 id)
        {
            var result = await _dbContext.Set<PortfolioModel>().FindAsync(id);
            return result as IModel;
        }

        public async Task<IModel> GetAsync(IModel entity)
        {
            try
            {
                PortfolioModel model = entity as PortfolioModel;
                PortfolioModel result = null;
                if (!String.IsNullOrEmpty(model.Title) && result == null)
                {
                    result = _dbContext.Set<PortfolioModel>().Where(p => p.Title == model.Title).FirstOrDefault();
                }
                return result as IModel;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return entity;
        }

        public IQueryable<IModel> GetMany(int pageSize, int pageNumber, string name)
        {
            try
            {
                var result = _dbContext.Set<PortfolioModel>().Take(pageSize);
                return result.Cast<IModel>();
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
                PortfolioModel model = entity as PortfolioModel;
                model.LastModified = DateTime.Now;
                _dbContext.Set<PortfolioModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return model as IModel;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleRepositoryException(ex);
            }
            return entity;
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
        // ~PortfolioRepository() {
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

        public Task<List<IModel>> AddRangeAsync(List<IModel> data)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
