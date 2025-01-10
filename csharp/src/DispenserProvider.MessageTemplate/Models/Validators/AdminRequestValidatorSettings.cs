using Net.Web3.EthereumWallet;
using Nethereum.Signer.EIP712;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class AdminRequestValidatorSettings(string nameOfRole, string signature, AbstractMessage message, IEnumerable<EthereumAddress> usersToValidateOrder)
{
    public string NameOfRole { get; } = nameOfRole;
    public string Signature { get; } = signature;
    public AbstractMessage Message { get; } = message;
    public IEnumerable<EthereumAddress> UsersToValidateOrder { get; } = usersToValidateOrder;

    public string RecoveredAddress => new Eip712TypedDataSigner()
            .RecoverFromSignatureV4(Message, Message.TypedData, Signature);
}