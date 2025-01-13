using Nethereum.ABI.EIP712;

namespace DispenserProvider.MessageTemplate.Models.Eip712;

public abstract class AbstractMessage
{
    protected abstract MemberValue[] MembersValues { get; }
    protected abstract Type[] MembersDescriptionTypes { get; }
    protected abstract bool IsCreate { get; }

    public TypedData<EIP712Domain> TypedData
    {
        get
        {
            var types = new List<Type> { typeof(EIP712Domain) };
            types.AddRange(MembersDescriptionTypes);
            var data = new TypedData<EIP712Domain>
            {
                Domain = new EIP712Domain(IsCreate),
                Types = MemberDescriptionFactory.GetTypesMemberDescription(types.ToArray()),
                PrimaryType = "SignMessage",
                Message = MembersValues
            };
            return data;
        }
    }
}