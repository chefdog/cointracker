using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.DataTransferModels
{
    public class BaseDto
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
    }
}
