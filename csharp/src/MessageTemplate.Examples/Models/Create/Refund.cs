﻿using Newtonsoft.Json;
using Net.Web3.EthereumWallet;
using Newtonsoft.Json.Converters;

namespace MessageTemplate.Examples.Models.Create;

public class Refund
{
    [JsonRequired]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime FinishTime { get; set; }

    [JsonRequired]
    public decimal Ratio { get; set; }

    [JsonRequired]
    public EthereumAddress DealProvider { get; set; } = null!;

    [JsonRequired]
    public long ChainId { get; set; }

    [JsonRequired]
    public long PoolId { get; set; }
}