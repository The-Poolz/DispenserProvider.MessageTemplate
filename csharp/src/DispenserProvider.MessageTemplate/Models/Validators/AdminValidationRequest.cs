using Newtonsoft.Json;
using Nethereum.Signer;
using Net.Web3.EthereumWallet;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class AdminValidationRequest<TMessage>(string nameOfRole, ValidatedAdminRequest<TMessage> adminRequest)
    where TMessage : IPlainMessage
{
    public string NameOfRole { get; } = nameOfRole;
    public string RecoveredAddress
    {
        get
        {
            return new EthereumMessageSigner()
                .EncodeUTF8AndEcRecover(
                    message: JsonConvert.SerializeObject(adminRequest.Message, Formatting.None),
                    signature: adminRequest.Signature
                );
        }
    }

    public IEnumerable<EthereumAddress> UsersToValidateOrder => adminRequest.Message.UsersToValidateOrder;
}