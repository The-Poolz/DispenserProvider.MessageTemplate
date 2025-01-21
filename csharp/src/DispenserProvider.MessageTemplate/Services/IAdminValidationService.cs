namespace DispenserProvider.MessageTemplate.Services;

public interface IAdminValidationService
{
    public bool IsValidAdmin(string userAddress);
}