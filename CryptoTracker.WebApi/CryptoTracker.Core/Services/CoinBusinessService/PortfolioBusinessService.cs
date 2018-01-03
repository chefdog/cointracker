﻿using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.Core.Services.CoinBusinessService
{
    public class PortfolioBusinessService : IBusinessService<PortfolioDataTransferModel>, IDisposable
    {
        private IRepository _repos;

        public PortfolioBusinessService(AppSettings appSettings) {
            _repos = new PortfolioRepository();
        }

        public Task<PortfolioDataTransferModel> Create(PortfolioDataTransferModel dto)
        {
            throw new NotImplementedException();
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
