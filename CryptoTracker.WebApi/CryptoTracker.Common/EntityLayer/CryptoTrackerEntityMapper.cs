using CryptoTracker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Common.EntityLayer
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
