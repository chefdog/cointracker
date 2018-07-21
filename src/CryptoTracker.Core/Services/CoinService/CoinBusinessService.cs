using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoTracker.DataAccess.Enums;
using CryptoTracker.Core.Models;
using CryptoTracker.Core.Services.Helpers;
using Microsoft.Extensions.Options;

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
        public CoinBusinessService(IOptions<AppSettings> appSettings, CTDbContext dbContext, IBusinessService<HistoryLogDataTransferModel> historyService) {
            _exchangeRepos = new ExchangeRepository(appSettings.Value.CoinMarketCap.BaseAddress, appSettings.Value.CoinMarketCap.Api, appSettings.Value.CoinMarketCap.QueryParams);
            _coinRepos = new CoinRepository(dbContext);
            _historyService = historyService;
            _appSettings = appSettings.Value;
        }

        public async Task<CoinDataTransferModel> Create(CoinDataTransferModel dto)
        {
            dto.Id = 0;
            try
            {
                var model = await _coinRepos.AddAsync(dto.ToModel()) as CoinModel;
                return model.ToDto();
            }
            catch (RepositoryException rex) {
                ExceptionHandler.ProcessRepositoryException(rex);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleBusinessServiceException(ex);
            }
            return dto;
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
                var historyLog = new HistoryLogDataTransferModel
                {
                    ParamKey = HistoryLogEnum.REMOTE_API.ToString(),
                    ParamValue = DateTime.Now.ToString()
                };
                bool shouldUpdate = false;
                //1. get info on latest request
                var historyData = await _historyService.GetMany(0, 0, 100);
                //2 if latest request is within range, proceed with database call
                if (historyData.Any())
                {
                    historyData = historyData.OrderByDescending(x => x.LastModified).ToList();
                    var query = from h in historyData
                                where h.LastModified.AddSeconds(_appSettings.CoinMarketCap.RefreshInterval) >= DateTime.Now
                                select h;
                    if (!query.Any()) { shouldUpdate = true; }
                }

                if (shouldUpdate) await insertRemoteData(historyLog);

                var coinData = _coinRepos.GetMany(1000, 0, "");
                if (coinData.Any())
                {
                    result = coinData.Cast<CoinModel>().Select(c => c.ToDto()).ToList();
                    return result;
                }
                else {
                    await insertRemoteData(historyLog);
                    coinData = _coinRepos.GetMany(1000, 0, "");
                    result = coinData.Cast<CoinModel>().Select(c => c.ToDto()).ToList();
                    return result;
                }
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
        private async Task insertRemoteData(HistoryLogDataTransferModel historyLogModel) {
            await _historyService.Create(historyLogModel);
            var remoteData = _exchangeRepos.GetMany(1000, 0, string.Empty).Cast<ExchangeModel>();
            var data = ServiceHelper.ExchangeModelToCoinModel(remoteData.ToList());
            await _coinRepos.AddRangeAsync(data.ToList<IModel>());
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
                _historyService.Dispose();
                _exchangeRepos.Dispose();
                _coinRepos.Dispose();
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
