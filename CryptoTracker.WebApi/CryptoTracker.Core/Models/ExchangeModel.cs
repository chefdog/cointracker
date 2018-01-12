using CryptoTracker.Common.Interfaces;
using System;
using System.Runtime.Serialization;

namespace CryptoTracker.Core.Models
{
    [DataContract]
    public class ExchangeModel : IModel
    {
        [DataMember(Name ="id")]
        public string Title { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "symbol")]
        public string Tag { get; set; }

        [DataMember(Name = "rank")]
        public string Rank { get; set; }

        [DataMember(Name = "price_usd")]
        public decimal UsdPrice { get; set; }

        [DataMember(Name = "price_btc")]
        public string BtcPrice { get; set; }

        [DataMember(Name = "24_volume_usd")]
        public string Volume { get; set; }

        [DataMember(Name = "market_cap_usd")]
        public string MarketCapInUsd { get; set; }

        [DataMember(Name = "market_cap_euro")]
        public string MarketCapInEuro { get; set; }

        [DataMember(Name = "available_supply")]
        public string AvailableSupply { get; set; }

        [DataMember(Name = "total_supply")]
        public string TotalSupply { get; set; }

        [DataMember(Name = "percent_change_1h")]
        public string PercentChangeOneHour { get; set; }

        [DataMember(Name = "percent_change_24h")]
        public string PercentChangeTwentyFoutHours{ get; set; }

        [DataMember(Name = "percent_change_7d")]
        public string PercentChangeSevenDays { get; set; }

        [DataMember(Name = "last_updated")]
        public string LastUpdate { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public int Rating { get; set; }
    }
}
