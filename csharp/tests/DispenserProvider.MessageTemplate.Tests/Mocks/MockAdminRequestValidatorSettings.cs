using Nethereum.Signer;
using Nethereum.ABI.EIP712;
using Nethereum.Signer.EIP712;
using DispenserProvider.MessageTemplate.Models.Eip712;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

internal static class MockAdminRequestValidatorSettings
{
    internal static AdminRequestValidatorSettings Create(AbstractMessage message, EthECKey privateKey)
    {
        var signature = new Eip712TypedDataSigner().SignTypedDataV4<EIP712Domain>(message.TypedData.ToJson(), privateKey);
        return new AdminRequestValidatorSettings(signature, message, []);
    }
}