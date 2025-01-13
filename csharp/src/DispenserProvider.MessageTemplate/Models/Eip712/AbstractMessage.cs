using Nethereum.ABI.EIP712;

namespace DispenserProvider.MessageTemplate.Models.Eip712;

public abstract class AbstractMessage
{
    protected abstract MemberValue[] MembersValues { get; }
    protected abstract Type[] MembersDescriptionTypes { get; }
    protected abstract bool IsCreate { get; }

    public TypedData<EIP712Domain> TypedData => new()
    {
        Domain = new EIP712Domain(IsCreate),
        Types = MemberDescriptionFactory.GetTypesMemberDescription(
            types: new[] { typeof(EIP712Domain) }
                .Concat(MembersDescriptionTypes)
                .ToArray()
        ),
        PrimaryType = "SignMessage",
        Message = MembersValues
    };
}