using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Common
{
    public class AppSettings
    {
        public String ConnectionString { get; set; }
        public CoinMarketCap CoinMarketCap{get;set;}
    }
}
