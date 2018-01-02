using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.Services.CoinBusinessService
{
    public class PortfolioBusinessService
    {
        private IRepository _repos;

        public PortfolioBusinessService(AppSettings appSettings) {
            _repos = new PortfolioRepository();
        }

        public List<PortfolioDataTransferModel> SelectMany() {
            List<PortfolioDataTransferModel> result = null;


            return result;
        }

        public PortfolioDataTransferModel Create(PortfolioDataTransferModel dto) {
            //1 get latest coin list

        }

        public PortfolioDataTransferModel Update(PortfolioDataTransferModel dto)
        {
            //1 get latest coin list

        }
    }
}
