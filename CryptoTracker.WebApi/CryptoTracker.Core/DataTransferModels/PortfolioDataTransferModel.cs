﻿using CryptoTracker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoTracker.Core.DataTransferModels
{
    public class PortfolioDataTransferModel : BaseDto, IModel
    {
        public bool IsPrivate { get; set; }
        public bool IsShared { get; set; }
        [Required]
        public Int64 UserId { get; set; }
        public string Description { get; set; }
        public List<PortfolioItemDataTransferModel> Items { get; set; }
    }
}
