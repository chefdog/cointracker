using System;

namespace CryptoTracker.Core.Models
{
    public class BaseModel
    {
        public Int64 Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string Title { get; set; }
        public Guid RowGuid { get; set; }
        public int Rating { get; set; }
    }
}
