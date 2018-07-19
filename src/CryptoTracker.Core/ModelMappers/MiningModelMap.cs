using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Core.ModelMappers
{
    public class MiningModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<MiningRigModel>();

            entity.ToTable("MiningRig", "ct");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }

    public class MiningItemModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<MiningItemModel>();

            entity.ToTable("MiningItem", "ct");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
