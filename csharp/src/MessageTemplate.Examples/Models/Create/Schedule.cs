using Newtonsoft.Json;
using Net.Web3.EthereumWallet;
using Newtonsoft.Json.Converters;

namespace MessageTemplate.Examples.Models.Create;

public class Schedule
{
    [JsonRequired]
    public EthereumAddress ProviderAddress { get; set; } = null!;

    [JsonRequired]
    public decimal Ratio { get; set; }

    [JsonRequired]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("StartTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime StartTime { get; set; }

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("FinishTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? FinishTime { get; set; }
}