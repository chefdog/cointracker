using CryptoTracker.Common.Interfaces;
using System.Collections.Generic;


namespace CryptoTracker.Core.ModelMappers
{
    public class CryptoTrackerEntityMapper : EntityMapper
    {
        public CryptoTrackerEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new ArticleModelMap() as IEntityMap,
                new CoinModelMap() as IEntityMap,
                new HistoryLogModelMap() as IEntityMap,
                new MiningModelMap() as IEntityMap,
                new MiningItemModelMap() as IEntityMap,
                new ParagraphModelMap() as IEntityMap,
                new PortfolioModelMap() as IEntityMap,
                new PortfolioItemModelMap() as IEntityMap,
                new UserAccountModelMap() as IEntityMap
            };
        }
    }
}
