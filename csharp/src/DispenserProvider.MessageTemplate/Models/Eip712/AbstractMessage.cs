using Nethereum.ABI.EIP712;

namespace DispenserProvider.MessageTemplate.Models.Eip712;

public abstract class AbstractMessage
{
    public abstract Type[] MembersDescriptionTypes { get; }
    public abstract bool IsCreate { get; }

    public TypedData<EIP712Domain> TypedData => new()
    {
        Domain = new EIP712Domain(IsCreate),
        Types = MemberDescriptionFactory.GetTypesMemberDescription(MembersDescriptionTypes),
        PrimaryType = "SignMessage"
    };
}