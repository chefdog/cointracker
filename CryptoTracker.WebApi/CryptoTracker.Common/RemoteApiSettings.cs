using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Common
{
    public class CoinMarketCap
    {
        public string BaseAddress { get; set; }
        public string Api {get;set;}

        public List<string> QueryParams = new List<string> {"limit={0}", "start={1}&limit={0}", "convert={1}&limit={0}"};
    }
}
