using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "users")]
public class User(EthereumAddress userAddress, string weiAmount)
{
    [Parameter(type: "address", name: "userAddress", order: 1)]
    public string UserAddress { get; } = userAddress;

    [Parameter(type: "string", name: "weiAmount", order: 2)]
    public string WeiAmount { get; } = weiAmount;
}