using CryptoTracker.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.Core.Models
{
    public class CoinPriceModel : BaseModel, IModel
    {
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
    }
}
