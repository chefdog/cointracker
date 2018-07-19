using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Exceptions;
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
                Title = "Test portfolio 1" + DateTime.Now.ToUniversalTime(),
                Description = "Test portfolio description"
            };

            var service = _serviceMocker.GetPortfolioService();
            var result = await service.Create(dto);

            service.Dispose();
            Assert.NotNull(result);            
        }

        [Fact]
        public async Task TestAlreadyExist()
        {
            try
            {
                PortfolioDataTransferModel dto = new PortfolioDataTransferModel
                {
                    UserId = 1,
                    Title = "Test portfolio 1",
                    Description = "Test portfolio description"
                };

                var service = _serviceMocker.GetPortfolioService();
                var result = await service.Create(dto);
                service.Dispose();
            }
            catch (ValidationException vex) {
                Assert.Contains("Entity already excist", vex.Message);
            }
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
