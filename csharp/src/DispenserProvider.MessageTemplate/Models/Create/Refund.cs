﻿using Nethereum.Util;
using System.Numerics;
using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "refund")]
public class Refund(long chainId, long poolId, string ratio, EthereumAddress dealProvider, long finishTime)
{
    public Refund(long chainId, long poolId, string ratio, EthereumAddress dealProvider, DateTime finishTime)
        : this(chainId, poolId, ratio, dealProvider, finishTime.ToUnixTimestamp())
    { }

    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public BigInteger ChainId { get; } = chainId;

    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public BigInteger PoolId { get; } = poolId;

    [Parameter(type: "string", name: "weiRatio", order: 3)]
    public string Ratio { get; } = ratio;

    [Parameter(type: "address", name: "dealProvider", order: 4)]
    public string DealProvider { get; } = dealProvider;

    [Parameter(type: "uint256", name: "finishTime", order: 5)]
    public BigInteger FinishTime { get; } = finishTime;
}