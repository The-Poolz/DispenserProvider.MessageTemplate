using Nethereum.Util;
using System.Numerics;
using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "Refund")]
public class Refund(long chainId, long poolId, string ratio, EthereumAddress dealProvider, DateTime finishTime)
{
    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public BigInteger ChainId { get; } = chainId;

    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public BigInteger PoolId { get; } = poolId;

    [Parameter(type: "uint256", name: "ratio", order: 3)]
    public BigInteger Ratio { get; } = BigInteger.Parse(ratio);

    [Parameter(type: "address", name: "dealProvider", order: 4)]
    public string DealProvider { get; } = dealProvider;

    [Parameter(type: "uint256", name: "finishTime", order: 5)]
    public BigInteger FinishTime { get; } = finishTime.ToUnixTimestamp();
}