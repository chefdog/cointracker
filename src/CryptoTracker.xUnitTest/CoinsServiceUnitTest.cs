using CryptoTracker.xUnitTest.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CryptoTracker.xUnitTest
{
    public class CoinsServiceUnitTest
    {
        private ServiceMocker _serviceMocker;
        public CoinsServiceUnitTest()
        {
            _serviceMocker = new ServiceMocker();
        }

        [Fact]
        public async Task TestGetCoins()
        {
            var service = _serviceMocker.GetCoinService();
            var data = await service.GetMany(0, 0, 1000);            
            Assert.NotNull(data);
            Assert.NotEmpty(data);
            service.Dispose();
        }
    }
}
