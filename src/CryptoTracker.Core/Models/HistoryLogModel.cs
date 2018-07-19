using CryptoTracker.Common.Interfaces;

namespace CryptoTracker.Core.Models
{
    public class HistoryLogModel : BaseModel, IModel
    {
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
    }
}
