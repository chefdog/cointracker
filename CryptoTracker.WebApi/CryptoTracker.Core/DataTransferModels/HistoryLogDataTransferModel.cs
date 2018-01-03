using CryptoTracker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.DataTransferModels
{
    public class HistoryLogDataTransferModel : BaseDto, IModel
    {
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
    }
}
