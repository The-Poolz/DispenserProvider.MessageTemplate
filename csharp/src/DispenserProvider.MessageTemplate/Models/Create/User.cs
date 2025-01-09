using Newtonsoft.Json;
using Net.Web3.EthereumWallet;
using Net.Web3.EthereumWallet.Json.Converters;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "User")]
public class User
{
    [JsonRequired]
    [JsonConverter(typeof(EthereumAddressConverter))]
    [Parameter(type: "address", name: "userAddress", order: 1)]
    public EthereumAddress UserAddress { get; set; } = null!;

    [JsonRequired]
    [Parameter(type: "uint256", name: "weiAmount", order: 2)]
    public string WeiAmount { get; set; } = null!;
}