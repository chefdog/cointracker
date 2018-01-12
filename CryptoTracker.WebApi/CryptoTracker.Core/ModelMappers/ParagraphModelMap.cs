using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Core.ModelMappers
{
    public class ParagraphModelMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ParagraphModel>();

            entity.ToTable("Paragraph", "ct");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
