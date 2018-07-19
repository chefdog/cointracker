using CryptoTracker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoTracker.Core.DataTransferModels
{
    public class PortfolioItemDataTransferModel : BaseDto, IModel
    {
        public string Description { get; set; }
        [Required]
        public string CoinTag { get; set; }
        public Int64 CoinId { get; set; }
        public decimal ListPrice { get; set; }
    }
}
