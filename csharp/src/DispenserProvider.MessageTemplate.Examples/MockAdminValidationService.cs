using Nethereum.Signer;
using DispenserProvider.MessageTemplate.Services;

namespace DispenserProvider.MessageTemplate.Examples;

internal class MockAdminValidationService : IAdminValidationService
{
    internal static EthECKey AdminPrivateKey => new("0xe290f27189205c280e53b6194580c24b4fc49c97047b5ffcb62201c4d38feece");
    internal static string AdminAddress => AdminPrivateKey.GetPublicAddress();

    public bool IsValidAdmin(string userAddress)
    {
        return userAddress == AdminAddress;
    }
}