using CryptoTracker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.DataAccess.Models
{
    public class CoinModel : BaseModel, IModel
    {
        public string Tag { get; set; }
        public decimal ListPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
