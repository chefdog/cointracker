using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.Core.Models
{
    public class BaseModel
    {
        [Required]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string Title { get; set; }
        public Guid RowGuid { get; set; }
        public int Rating { get; set; }
    }
}
