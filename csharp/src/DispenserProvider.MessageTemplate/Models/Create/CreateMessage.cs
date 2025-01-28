using System.Numerics;
using Nethereum.ABI.EIP712;
using Nethereum.ABI.FunctionEncoding.Attributes;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "SignMessage")]
public class CreateMessage(long chainId, long poolId, IEnumerable<Schedule> schedules, IEnumerable<User> users) : AbstractMessage
{
    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public BigInteger ChainId { get; } = chainId;

    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public BigInteger PoolId { get; } = poolId;

    [Parameter(type: "tuple[]", name: "schedules", order: 3, structTypeName: "schedules[]")]
    public Schedule[] Schedules { get; } = schedules.ToArray();

    [Parameter(type: "tuple[]", name: "users", order: 4, structTypeName: "users[]")]
    public User[] Users { get; } = users.ToArray();

    protected override bool IsCreate => true;
    protected override Type[] MembersDescriptionTypes => [typeof(CreateMessage), typeof(Schedule), typeof(User)];
    protected override MemberValue[] MembersValues => MemberValueFactory.CreateFromMessage(this);
}