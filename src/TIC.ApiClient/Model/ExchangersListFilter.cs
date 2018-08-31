using System.Collections.Generic;
using Newtonsoft.Json;

namespace TIC.ApiClient.Model
{
    public partial class ExchangersListFilter
    {
        [JsonProperty("filter")] public Filter filter = new Filter();

        [JsonProperty("startFrom")] public int startFrom;
    }

    public partial class Filter
    {
        [JsonProperty("UserID")] public string UserID = "";

        [JsonProperty("Text")] public string Text = "";

        [JsonProperty("Url")] public string Url = "";

        [JsonProperty("OKPAYWallet")] public string OKPAYWallet = "";

        [JsonProperty("WMID")] public string WMID = "";

        [JsonProperty("Statuses")] public List<string> Statuses = new List<string>();

        [JsonProperty("IsFollowUTICorrect")] public string IsFollowUTICorrect = "";

        [JsonProperty("HasRatesErrors")] public string HasRatesErrors = "";

        [JsonProperty("IsRefURLEmpty")] public string IsRefURLEmpty = "";

        [JsonProperty("IsHidden")] public string IsHidden = "";

        [JsonProperty("IsUntrusted")] public string IsUntrusted = "";
    }
}