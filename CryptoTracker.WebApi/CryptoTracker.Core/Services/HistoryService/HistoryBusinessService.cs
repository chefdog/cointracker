using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Exceptions;

namespace CryptoTracker.Core.Services.HistoryService
{
    public class HistoryBusinessService : IBusinessService<HistoryLogDataTransferModel>, IDisposable
    {
        private IRepository _repos;
        
        public HistoryBusinessService(AppSettings appSettings, CTDbContext dbContext) {
            _repos = new HistoryLogRepository(dbContext);
        }

        public Task<HistoryLogDataTransferModel> Create(HistoryLogDataTransferModel dto)
        {
            try
            {
                
                
            }
            catch (RepositoryException rex) {
                ExceptionHandler.ProcessRepositoryException(rex);
            }
            catch (Exception ex) {
                ExceptionHandler.HandleBusinessServiceException(ex);
            }
            return null;
        }

        public Task<HistoryLogDataTransferModel> Find(HistoryLogDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<HistoryLogDataTransferModel>> GetMany(int start, int skip, int max)
        {
            throw new NotImplementedException();
        }

        public Task<HistoryLogDataTransferModel> Remove(HistoryLogDataTransferModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<HistoryLogDataTransferModel> Update(HistoryLogDataTransferModel dto)
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
        // ~HistoryBusinessService() {
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
