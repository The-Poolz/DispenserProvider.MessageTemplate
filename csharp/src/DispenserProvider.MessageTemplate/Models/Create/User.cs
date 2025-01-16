using System.Numerics;
using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "User")]
public class User(EthereumAddress userAddress, string weiAmount)
{
    [Parameter(type: "address", name: "userAddress", order: 1)]
    public string UserAddress { get; } = userAddress;

    [Parameter(type: "uint256", name: "weiAmount", order: 2)]
    public BigInteger WeiAmount { get; } = BigInteger.Parse(weiAmount);
}