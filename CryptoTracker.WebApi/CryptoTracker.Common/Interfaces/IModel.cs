using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Common.Interfaces
{
    public interface IModel
    {
        DateTime Created { get; set; }
        DateTime LastModified { get; set; }
        string LastModifiedBy { get; set; }
        string Title { get; set; }
        int Rating { get; set; }
    }
}
