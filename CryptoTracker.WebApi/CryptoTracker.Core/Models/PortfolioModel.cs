using System;
using CryptoTracker.Common.Interfaces;

namespace CryptoTracker.Core.Models
{
    public class PortfolioModel : BaseModel, IModel
    {
        public bool IsPrivate { get; set; }
        public bool IsShared { get; set; }
        public Int64 UserId { get; set; }
        public string Description { get; set; }
    }
}
