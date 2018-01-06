using CryptoTracker.Common;
using CryptoTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.Core.Initializr
{
    class CoinTrackerInitialzr
    {
        private CTDbContext _context;

        public CoinTrackerInitialzr(CTDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            //var current = _context.Set<PortfolioModel>();
            //current.

            //{
            //    _context.AddRange(_personCategoryStatus);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
