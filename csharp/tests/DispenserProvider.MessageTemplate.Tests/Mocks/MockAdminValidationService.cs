using DispenserProvider.MessageTemplate.Services;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

internal class MockAdminValidationService : IAdminValidationService
{
    internal static string Role => "DispenserAdmin";
    internal static string AdminAddress => MockUsers.Admin.Address;

    public bool IsValidAdmin(string userAddress, string nameOfRole)
    {
        return userAddress == AdminAddress && nameOfRole == Role;
    }
}