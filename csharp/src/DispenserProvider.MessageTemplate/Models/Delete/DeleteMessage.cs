using Newtonsoft.Json;
using Net.Web3.EthereumWallet;
using Net.Web3.EthereumWallet.Json.Converters;

namespace DispenserProvider.MessageTemplate.Models.Delete;

public class DeleteMessage
{
    [JsonRequired]
    public long ChainId { get; set; }

    [JsonRequired]
    public long PoolId { get; set; }

    [JsonRequired]
    [JsonConverter(typeof(EthereumAddressConverter))]
    public EthereumAddress[] Users { get; set; } = null!;
}