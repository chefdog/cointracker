using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CryptoTracker.Common;
using CryptoTracker.Core.Models;


namespace CryptoTracker.Core.Initializr
{
    public class CoinTrackerInitialzr
    {
        private CTDbContext _context;
        private string _fileLocation = @"D:\Sources\Repos\CoinTracker\src\CryptoTracker.WebApi\App_Data\Portfolio.csv";
        private List<List<string>> records = null;
        public CoinTrackerInitialzr(CTDbContext context)
        {
            _context = context;
            records = new List<List<string>>();
        }

        public async Task Seed()
        {
            RemoveAllData();
            LoadFile();
            LoadPortfolioItems();

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

        private void LoadFile() {
            
            
        }

        private void LoadPortfolioItems() {
            var data = records.Skip(1);

            
        }

        private void RemoveAllData() {
            _context.Set<PortfolioItemModel>().RemoveRange();
            _context.Set<CoinModel>().RemoveRange();            
            _context.Set<ArticleModel>().RemoveRange();
            _context.Set<UserAccountModel>().RemoveRange();
            _context.Set<MiningItemModel>().RemoveRange();
            _context.Set<ArticleModel>().RemoveRange();
            _context.Set<MiningRigModel>().RemoveRange();
            _context.Set<PortfolioModel>().RemoveRange();
        }

        private Decimal ConvertToDecimal(string item) {
            decimal decval;
            bool convt = decimal.TryParse(item, NumberStyles.Currency,
            CultureInfo.CurrentCulture.NumberFormat, out decval);
            if (convt)
            {
                return decval;
            }
            else {
                var numberWithoutMoneyFormatting = Regex.Replace(item, @"[^\d,-]", "");
                return decimal.Parse(numberWithoutMoneyFormatting);
            }
        }
    }
}
