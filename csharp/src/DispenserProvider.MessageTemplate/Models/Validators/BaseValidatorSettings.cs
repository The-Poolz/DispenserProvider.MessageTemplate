using Net.Web3.EthereumWallet;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class BaseValidatorSettings(AdminRequestValidatorSettings adminValidatorSettings, IEnumerable<EthereumAddress> users)
{
    public AdminRequestValidatorSettings AdminRequestValidatorSettings { get; } = adminValidatorSettings;
    public IEnumerable<EthereumAddress> Users { get; } = users;
}