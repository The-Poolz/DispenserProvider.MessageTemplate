using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Create;

[Struct(name: "SignMessage")]
public class CreateMessageWithRefund(long chainId, long poolId, Schedule[] schedules, User[] users, Refund refund)
    : CreateMessage(chainId, poolId, schedules, users)
{
    [Parameter(type: "tuple", name: "refund", order: 5, structTypeName: "Refund")]
    public Refund Refund { get; } = refund;

    public override Type[] MembersDescriptionTypes => [typeof(CreateMessageWithRefund), typeof(Schedule), typeof(User), typeof(Refund)];
}