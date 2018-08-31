namespace TIC.ApiClient.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Exchangers
    {
        [JsonProperty("Collection")]
        public Collection Collection { get; set; }

        [JsonProperty("Balances")]
        public Dictionary<string, double?> Balances { get; set; }
    }

    public partial class Collection
    {
        [JsonProperty("ItemsCount")]
        public long ItemsCount { get; set; }

        [JsonProperty("LoadPosition")]
        public long LoadPosition { get; set; }

        [JsonProperty("Result")]
        public List<Result> Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("StatusName")]
        public string StatusName { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("UserFirstName")]
        public string UserFirstName { get; set; }

        [JsonProperty("UserLastName")]
        public string UserLastName { get; set; }

        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("UserID")]
        public long UserId { get; set; }

        [JsonProperty("Status")]
        public long Status { get; set; }

        [JsonProperty("FollowersCount")]
        public long FollowersCount { get; set; }

        [JsonProperty("AlexaRank")]
        public object AlexaRank { get; set; }

        [JsonProperty("RouteUrl")]
        public string RouteUrl { get; set; }

        [JsonProperty("LastMonthEarnings")]
        public object LastMonthEarnings { get; set; }

        [JsonProperty("TotalEarnings")]
        public object TotalEarnings { get; set; }
    }

//    public enum StatusName { Enabled, New, NoRates, SuspendedByManager };
}