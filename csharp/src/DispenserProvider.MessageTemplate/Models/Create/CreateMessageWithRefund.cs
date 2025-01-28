using Nethereum.ABI.EIP712;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "SignMessage")]
public class CreateMessageWithRefund(long chainId, long poolId, IEnumerable<Schedule> schedules, IEnumerable<User> users, Refund refund)
    : CreateMessage(chainId, poolId, schedules, users)
{
    [Parameter(type: "tuple", name: "refund", order: 5, structTypeName: "refund")]
    public Refund Refund { get; } = refund;

    protected override Type[] MembersDescriptionTypes => [typeof(CreateMessageWithRefund), typeof(Schedule), typeof(User), typeof(Refund)];
    protected override MemberValue[] MembersValues => MemberValueFactory.CreateFromMessage(this);
}