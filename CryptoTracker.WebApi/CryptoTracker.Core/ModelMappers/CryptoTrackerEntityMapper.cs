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
                new CoinModelMap() as IEntityMap
            };
        }
    }
}
