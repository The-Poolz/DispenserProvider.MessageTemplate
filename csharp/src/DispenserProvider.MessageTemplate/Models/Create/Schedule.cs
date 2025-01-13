using Nethereum.Util;
using System.Numerics;
using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "Schedule")]
public class Schedule(EthereumAddress providerAddress, string ratio, long startDate, long finishDate)
{
    public Schedule(EthereumAddress providerAddress, string ratio, DateTime startDate, DateTime finishDate)
        : this(providerAddress, ratio, startDate.ToUnixTimestamp(), finishDate.ToUnixTimestamp())
    { }

    [Parameter(type: "address", name: "providerAddress", order: 1)]
    public string ProviderAddress { get; } = providerAddress;

    [Parameter(type: "uint256", name: "ratio", order: 2)]
    public BigInteger Ratio { get; } = BigInteger.Parse(ratio);

    [Parameter(type: "uint256", name: "startTime", order: 3)]
    public BigInteger StartDate { get; } = startDate;

    [Parameter(type: "uint256", name: "finishTime", order: 4)]
    public BigInteger FinishDate { get; } = finishDate;
}