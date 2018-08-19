using CryptoTracker.Common.Interfaces;

namespace CryptoTracker.Core.Models
{
    public class CoinModel : BaseModel, IModel
    {
        public string Tag { get; set; }
        public decimal ListPrice { get; set; }
        
    }
}
