using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.xUnitTest.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CryptoTracker.xUnitTest
{
    public class PortfolioUnitTest
    {
        private ServiceMocker _serviceMocker;
        public PortfolioUnitTest() {
            _serviceMocker = new ServiceMocker();
        }

        [Fact]
        public async Task TestCreateNew()
        {
            PortfolioDataTransferModel dto = new PortfolioDataTransferModel {
                UserId = 1,
                Title = "Test portfolio 1",
                Description = "Test portfolio description"
            };

            var service = _serviceMocker.GetPortfolioService();
            var result = await service.Create(dto);

            service.Dispose();
            Assert.NotNull(result);            
        }
        [Fact]
        public async Task TestUpdatePortfolio() {
            PortfolioDataTransferModel dto = new PortfolioDataTransferModel
            {
                UserId = 1,
                Title = "Test portfolio 1",
                Description = "Test portfolio description"
            };

            PortfolioItemDataTransferModel item = new PortfolioItemDataTransferModel
            {
                 CoinTag = "BTC",
                 ListPrice = 1000,
                 Title = "Bitcoin",
                 LastModified = DateTime.Now,
                 LastModifiedBy = "Marco",
                 Created = DateTime.Now
            };

            dto.Items.Add(item);
            var portfolioService = _serviceMocker.GetPortfolioService();
            var portfolio = await portfolioService.Update(dto);

            portfolioService.Dispose();
            Assert.NotNull(portfolio);
        }
    }
}
