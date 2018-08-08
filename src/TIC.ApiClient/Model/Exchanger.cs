// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using TIC.ApiClient.Model;
//
//    var exchanger = Exchanger.FromJson(jsonString);

namespace TIC.ApiClient.Model
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Exchanger
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
        public StatusName StatusName { get; set; }

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

    public enum StatusName { Enabled };

    public partial class Exchanger
    {
        public static Exchanger FromJson(string json) => JsonConvert.DeserializeObject<Exchanger>(json, TIC.ApiClient.Model.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Exchanger self) => JsonConvert.SerializeObject(self, TIC.ApiClient.Model.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                StatusNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class StatusNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StatusName) || t == typeof(StatusName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Enabled")
            {
                return StatusName.Enabled;
            }
            throw new Exception("Cannot unmarshal type StatusName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StatusName)untypedValue;
            if (value == StatusName.Enabled)
            {
                serializer.Serialize(writer, "Enabled");
                return;
            }
            throw new Exception("Cannot marshal type StatusName");
        }

        public static readonly StatusNameConverter Singleton = new StatusNameConverter();
    }
}
