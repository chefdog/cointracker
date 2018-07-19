using CryptoTracker.Common.Interfaces;


namespace CryptoTracker.Core.DataTransferModels
{
    public class CoinDataTransferModel : BaseDto, IModel
    {
        public string Tag { get; internal set; }
        public decimal ListPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
