using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using DispenserProvider.MessageTemplate.Models.Eip712;
using Nethereum.ABI.EIP712;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "SignMessage")]
public class CreateMessage(long chainId, long poolId, IEnumerable<Schedule> schedules, IEnumerable<User> users) : AbstractMessage
{
    [Parameter(type: "uint256", name: "chainId", order: 1)]
    public BigInteger ChainId { get; } = chainId;

    [Parameter(type: "uint256", name: "poolId", order: 2)]
    public BigInteger PoolId { get; } = poolId;

    [Parameter(type: "tuple[]", name: "schedules", order: 3, structTypeName: "Schedule[]")]
    public List<Schedule> Schedules { get; } = schedules.ToList();

    [Parameter(type: "tuple[]", name: "users", order: 4, structTypeName: "User[]")]
    public List<User> Users { get; } = users.ToList();

    protected override bool IsCreate => true;
    protected override Type[] MembersDescriptionTypes => [typeof(CreateMessage), typeof(Schedule), typeof(User)];
    protected override MemberValue[] MembersValues => MemberValueFactory.CreateFromMessage(this);
}