using DispenserProvider.MessageTemplate.Services;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

internal class MockAdminValidationService : IAdminValidationService
{
    internal static string AdminAddress => MockUsers.Admin.Address;

    public bool IsValidAdmin(string userAddress)
    {
        return userAddress == AdminAddress;
    }
}