using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Core.DataTransferModels
{
    public class ArticleDataTransferModel : BaseDto
    {
        public Int64 UserId { get; set; }
        public Int64 CoinId { get; set; }
        public List<ParagraphDataTransferModel> Paragraphs { get; set; }
    }
}
