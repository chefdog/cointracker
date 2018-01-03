using Microsoft.EntityFrameworkCore;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;

namespace CryptoTracker.Core.ModelMappers
{
    public class PortfolioModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PortfolioModel>();

            entity.ToTable("Portfolio", "ct");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
