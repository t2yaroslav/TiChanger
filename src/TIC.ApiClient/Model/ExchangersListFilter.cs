using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TIC.ApiClient.Model
{
    public partial class ExchangersListFilter
    {
        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        [JsonProperty("startFrom")]
        public long StartFrom { get; set; }
    }

    public partial class Filter
    {
        [JsonProperty("UserID")]
        public string UserId { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("OKPAYWallet")]
        public string OkpayWallet { get; set; }

        [JsonProperty("WMID")]
        public string Wmid { get; set; }

        [JsonProperty("Statuses")]
        public List<object> Statuses { get; set; }

        [JsonProperty("IsFollowURLCorrect")]
        public string IsFollowUrlCorrect { get; set; }

        [JsonProperty("HasRatesErrors")]
        public string HasRatesErrors { get; set; }

        [JsonProperty("IsRefURLEmpty")]
        public string IsRefUrlEmpty { get; set; }

        [JsonProperty("IsHidden")]
        public string IsHidden { get; set; }

        [JsonProperty("IsUntrusted")]
        public string IsUntrusted { get; set; }
    }


}
