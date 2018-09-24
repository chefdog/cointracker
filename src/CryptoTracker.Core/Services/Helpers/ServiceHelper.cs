using CryptoTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoTracker.Core.Services.Helpers
{
    public static class ServiceHelper
    {
        public static List<ExchangeModel> CoinModelToExchangeModel (List<CoinModel> data) {
            if (data.Any()) {
                var query = (from c in data select new ExchangeModel {
                    Name = c.Title,
                    Tag = c.Tag,
                    Created = c.Created,
                    LastModified = c.LastModified
                });
                return query.ToList();
            }
            return null;
        }

        public static List<CoinModel> ExchangeModelToCoinModel(List<ExchangeModel> data)
        {
            if (data.Any())
            {
                var query = (from c in data
                             select new CoinModel
                             {
                                 Title = c.Name,
                                 Tag = c.Tag,
                                 Created = c.Created,
                                 LastModified = c.LastModified,
                                 PriceModel = new CoinPriceModel { ListPrice = c.UsdPrice }
                             });
                return query.ToList();
            }
            return null;
        }
    }
}
