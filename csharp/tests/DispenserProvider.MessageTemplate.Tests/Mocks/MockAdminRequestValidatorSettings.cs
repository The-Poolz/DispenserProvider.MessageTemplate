using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Models.Eip712;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

internal static class MockAdminRequestValidatorSettings
{
    internal static AdminRequestValidatorSettings Create<TMessage>(TMessage message, string nameOfRole, IEnumerable<EthereumAddress> usersToValidateOrder, EthECKey privateKey)
        where TMessage : AbstractMessage
    {
        var signer = new Eip712TypedDataSigner();
        var signature = signer.SignTypedDataV4(message, message.TypedData, privateKey);
        return new AdminRequestValidatorSettings(nameOfRole, signature, message, usersToValidateOrder);
    }
}