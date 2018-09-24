using System;
using System.ComponentModel.DataAnnotations.Schema;
using CryptoTracker.Common.Interfaces;

namespace CryptoTracker.Core.Models
{
    public class PortfolioItemModel : BaseModel, IModel
    {
        public Int64 CoinModelId { get; set; }
        public Int64 MiningModelId { get; set; }
        public Int64 PortfolioId { get; set; }
        
    }
}
