using CryptoTracker.Common.Interfaces;
using CryptoTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.DataAccess.ModelMappers
{
    public class CoinModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CoinModel>();

            entity.ToTable("Coin", "ct");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
