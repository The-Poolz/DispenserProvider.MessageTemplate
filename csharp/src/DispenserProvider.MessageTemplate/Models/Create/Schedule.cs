using Newtonsoft.Json;
using Net.Web3.EthereumWallet;
using Newtonsoft.Json.Converters;
using Net.Web3.EthereumWallet.Json.Converters;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "Schedule")]
public class Schedule
{
    [JsonRequired]
    [JsonConverter(typeof(EthereumAddressConverter))]
    [Parameter(type: "address", name: "providerAddress", order: 1)]
    public EthereumAddress ProviderAddress { get; set; } = null!;

    [JsonRequired]
    [Parameter(type: "uint256", name: "ratio", order: 2)]
    public decimal Ratio { get; set; }

    [JsonRequired]
    [JsonProperty("StartTime")]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [Parameter(type: "uint256", name: "startTime", order: 3)]
    public DateTime StartDate { get; set; }

    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("FinishTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [Parameter(type: "uint256", name: "finishTime", order: 4)]
    public DateTime? FinishDate { get; set; }
}