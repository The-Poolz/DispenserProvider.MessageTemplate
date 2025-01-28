using Nethereum.Util;
using System.Numerics;
using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "schedules")]
public class Schedule(EthereumAddress providerAddress, string ratio, long startDate, long finishDate)
{
    public Schedule(EthereumAddress providerAddress, string ratio, DateTime startDate, DateTime finishDate)
        : this(providerAddress, ratio, startDate.ToUnixTimestamp(), finishDate.ToUnixTimestamp())
    { }

    [Parameter(type: "address", name: "providerAddress", order: 1)]
    public string ProviderAddress { get; } = providerAddress;

    [Parameter(type: "string", name: "weiRatio", order: 2)]
    public string Ratio { get; } = ratio;

    [Parameter(type: "uint256", name: "startTime", order: 3)]
    public BigInteger StartDate { get; } = startDate;

    [Parameter(type: "uint256", name: "finishTime", order: 4)]
    public BigInteger FinishDate { get; } = finishDate;
}