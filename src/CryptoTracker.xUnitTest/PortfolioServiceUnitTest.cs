using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Exceptions;
using CryptoTracker.xUnitTest.Common;
using System;
using System.Linq;
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
                Title = "Test portfolio 1" + DateTime.Now.ToUniversalTime(),
                Description = "Test portfolio description"
            };

            var service = _serviceMocker.GetPortfolioService();
            var result = await service.Create(dto);

            service.Dispose();
            Assert.NotNull(result);            
        }

        [Fact]
        public async Task TestCreateNewWithCoins()
        {
            PortfolioDataTransferModel dto = new PortfolioDataTransferModel
            {
                UserId = 1,
                Title = "Test portfolio 2" + DateTime.Now.ToUniversalTime(),
                Description = "Test portfolio with coins"
            };

            var coinsService = _serviceMocker.GetCoinService();
            var data = await coinsService.GetMany(0, 0, 1000);
            Assert.NotNull(data);
            Assert.NotEmpty(data);
            coinsService.Dispose();

            dto.Items = (from c in data
                         select new PortfolioItemDataTransferModel
                         {
                             CoinId = c.Id,
                             Created = c.Created,
                             CoinTag = c.Tag,
                             Title = c.Title,
                             ListPrice = c.ListPrice,
                             LastModified = c.LastModified,
                             LastModifiedBy = c.LastModifiedBy,
                             Rating = c.Rating
                         }).ToList();

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
                Description = "Test portfolio description",
                Id = 1
            };

            PortfolioItemDataTransferModel item = new PortfolioItemDataTransferModel
            {
                 CoinTag = "BTC",
                 ListPrice = 1000m,
                 Title = "Bitcoin",
                 LastModified = DateTime.Now,
                 LastModifiedBy = "Marco",
                 Created = DateTime.Now
            };
            dto.Items.Add(item);

            item = new PortfolioItemDataTransferModel
            {
                CoinTag = "LTC",
                ListPrice = 159.68m,
                Title = "Litecoin",
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
