using Newtonsoft.Json;

namespace MessageTemplate.Examples.Models.Create;

public class CreateMessage
{
    [JsonRequired]
    public Schedule[] Schedules { get; set; } = [];

    [JsonRequired]
    public User[] Users { get; set; } = [];

    public Refund? Refund { get; set; }

    [JsonRequired]
    public long ChainId { get; set; }

    [JsonRequired]
    public long PoolId { get; set; }
}