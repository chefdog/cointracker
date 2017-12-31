using CryptoTracker.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Common.EntityLayer
{
    public class CoinModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CoinModel>();

            entity.ToTable("Product", "Production");

            entity.HasKey(p => new { p.ProductID });

            entity.Property(p => p.ProductID).UseSqlServerIdentityColumn();
        }
    }
}
