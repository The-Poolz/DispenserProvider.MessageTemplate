using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "SignMessage")]
public class CreateMessage(long chainId, long poolId, Schedule[] schedules, User[] users) : AbstractMessage
{
    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public BigInteger ChainId { get; } = chainId;

    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public BigInteger PoolId { get; } = poolId;

    [Parameter(type: "tuple[]", name: "schedules", order: 3, structTypeName: "Schedule[]")]
    public Schedule[] Schedules { get; } = schedules;

    [Parameter(type: "tuple[]", name: "users", order: 4, structTypeName: "User[]")]
    public User[] Users { get; } = users;

    public override bool IsCreate => true;
    public override Type[] MembersDescriptionTypes => [typeof(CreateMessage), typeof(Schedule), typeof(User)];
}