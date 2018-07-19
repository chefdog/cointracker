using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.Models
{
    public class ParagraphModel : BaseModel
    {
        public string Paragraph { get; set; }
        public Int64 ArticleId { get; set; }
    }
}
