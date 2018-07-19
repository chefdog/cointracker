using CryptoTracker.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CryptoTracker.Core.ModelMappers
{
    public class EntityMapper : IEntityMapper
    {
        public IEnumerable<IEntityMap> Mappings { get; protected set; }

        public void MapEntities(ModelBuilder modelBuilder)
        {
            foreach (var item in Mappings)
            {
                item.Map(modelBuilder);
            }
        }
    }
}
