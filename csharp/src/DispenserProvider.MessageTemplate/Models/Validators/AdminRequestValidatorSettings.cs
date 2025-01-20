using Nethereum.ABI.EIP712;
using Nethereum.Signer.EIP712;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class AdminRequestValidatorSettings(string nameOfRole, string signature, AbstractMessage message)
{
    public string NameOfRole { get; } = nameOfRole;
    public string Signature { get; } = signature;
    public AbstractMessage Message { get; } = message;

    public string RecoveredAddress => new Eip712TypedDataSigner().RecoverFromSignatureV4(Message.TypedData.ToJson(), Signature);
}