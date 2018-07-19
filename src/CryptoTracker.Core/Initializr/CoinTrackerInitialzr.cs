using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoTracker.Common;
using CryptoTracker.Core.Models;


namespace CryptoTracker.Core.Initializr
{
    public class CoinTrackerInitialzr
    {
        private CTDbContext _context;

        public CoinTrackerInitialzr(CTDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            List<UserAccountModel> accounts = new List<UserAccountModel>();
            var usr = new UserAccountModel { Created = DateTime.Now, Email = "marco@chefdog.com", FirstName = "Marco", LastModified = DateTime.Now, LastModifiedBy = "System", LastName = "van Zuijlen", Title = "", Password = "1BitCo!n31" };
            accounts.Add(usr);
            usr = new UserAccountModel { Created = DateTime.Now, Email = "erik@purplefox.nl", FirstName = "Erik", LastModified = DateTime.Now, LastModifiedBy = "System", LastName = "Peschier", Title = "", Password = "1BitCo!n32" };
            accounts.Add(usr);
            usr = new UserAccountModel { Created = DateTime.Now, Email = "dennals@gmail.com", FirstName = "Daniel", LastModified = DateTime.Now, LastModifiedBy = "System", LastName = "Ennals", Title = "", Password = "1BitCo!n33" };
            accounts.Add(usr);

            await _context.Set<UserAccountModel>().AddRangeAsync(accounts);
            await _context.SaveChangesAsync();
        }        
    }
}
