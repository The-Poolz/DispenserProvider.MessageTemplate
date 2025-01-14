using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using DispenserProvider.MessageTemplate.Models.Eip712;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

internal static class MockAdminRequestValidatorSettings
{
    internal static AdminRequestValidatorSettings Create(AbstractMessage message, string nameOfRole, EthECKey privateKey)
    {
        var signature = new Eip712TypedDataSigner().SignTypedDataV4(message, message.TypedData, privateKey);
        return new AdminRequestValidatorSettings(nameOfRole, signature, message);
    }
}