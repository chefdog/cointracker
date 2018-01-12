using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.Models
{
    public class ArticleModel : BaseModel
    {
        public string ArticleType { get; set; }
        public Int64 UserId { get; set; }
        public Int64 CoinId { get; set; }
        public Int64 PortfolioId { get; set; }
    }
}
