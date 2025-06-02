using Nethereum.ABI.EIP712;
using Nethereum.Signer.EIP712;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class AdminRequestValidatorSettings(string signature, AbstractMessage message, IEnumerable<long> chainIDs)
{
    public IEnumerable<long> ChainIDs { get; } = chainIDs;
    public string Signature { get; } = signature;
    public AbstractMessage Message { get; } = message;

    public string RecoveredAddress => new Eip712TypedDataSigner().RecoverFromSignatureV4(Message.TypedData.ToJson(), Signature);
}