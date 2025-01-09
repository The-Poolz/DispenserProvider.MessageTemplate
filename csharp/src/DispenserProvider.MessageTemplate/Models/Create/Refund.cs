using Newtonsoft.Json;
using Net.Web3.EthereumWallet;
using Newtonsoft.Json.Converters;
using Net.Web3.EthereumWallet.Json.Converters;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "Refund")]
public class Refund
{
    [JsonRequired]
    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public long ChainId { get; set; }

    [JsonRequired]
    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public long PoolId { get; set; }

    [JsonRequired]
    [Parameter(type: "uint256", name: "ratio", order: 3)]
    public decimal Ratio { get; set; }

    [JsonRequired]
    [JsonConverter(typeof(EthereumAddressConverter))]
    [Parameter(type: "address", name: "dealProvider", order: 4)]
    public EthereumAddress DealProvider { get; set; } = null!;

    [JsonRequired]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [Parameter(type: "uint256", name: "finishTime", order: 5)]
    public DateTime FinishTime { get; set; }
}