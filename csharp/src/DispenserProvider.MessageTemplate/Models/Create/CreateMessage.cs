using Newtonsoft.Json;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "SignMessage")]
public class CreateMessage
{
    [JsonRequired]
    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public long ChainId { get; set; }

    [JsonRequired]
    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public long PoolId { get; set; }

    [JsonRequired]
    [Parameter(type: "Schedule[]", name: "schedules", order: 3)]
    public Schedule[] Schedules { get; set; } = [];

    [JsonRequired]
    [Parameter(type: "User[]", name: "users", order: 4)]
    public User[] Users { get; set; } = [];

    [Parameter(type: "Refund", name: "refund", order: 5)]
    public Refund? Refund { get; set; }
}