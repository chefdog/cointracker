using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.DataAccess.Models
{
    public class PortfolioItemModel : BaseModel
    {
        public Int64 CoinModelId { get; set; }
        public Int64 MiningModelId { get; set; }
        public Int64 PortfolioId { get; set; }
    }
}
