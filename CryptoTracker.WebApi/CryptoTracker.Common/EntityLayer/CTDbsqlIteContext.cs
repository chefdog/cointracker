using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace ryptoTracker.Common
{
    public class CTDbsqlIteContext : DbContext
    {
        public String ConnectionString { get; }

        public IEntityMapper EntityMapper { get; }

        public CTDbsqlIteContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;
            EntityMapper = entityMapper;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}