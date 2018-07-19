using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Core.ModelMappers
{
    public class ArticleModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ArticleModel>();

            entity.ToTable("Article", "ct");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }    
}
