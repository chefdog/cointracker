using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Common.Interfaces
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
