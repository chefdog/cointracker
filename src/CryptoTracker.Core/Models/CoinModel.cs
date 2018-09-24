using CryptoTracker.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoTracker.Core.Models
{
    public class CoinModel : BaseModel, IModel
    {
        public string Tag { get; set; }
        
        public long PriceId { get; set; }

        [NotMapped]
        public CoinPriceModel PriceModel { get; set; }
    }
}
