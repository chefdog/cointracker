﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.DataTransferModels
{
    public class PortfolioDataTransferModel : BaseDto
    {
        public bool IsPrivate { get; set; }
        public bool IsShared { get; set; }
        public Int64 UserId { get; set; }
        public string Description { get; set; }

        
    }
}
