using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.DataAccess.Models
{
    public class PortfolioModel : BaseModel
    {
        public bool IsPrivate { get; set; }
        public bool IsShared { get; set; }
        public Int64 UserId { get; set; }
        public string Description { get; set; }
    }
}
