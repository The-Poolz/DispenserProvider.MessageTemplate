using Net.Web3.EthereumWallet;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class CreateValidatorSettings(
    AdminRequestValidatorSettings adminRequestValidatorSettings,
    IEnumerable<EthereumAddress> usersToValidateOrder,
    IEnumerable<IValidatedScheduleItem> schedulesToValidateOrder
)
{
    public AdminRequestValidatorSettings AdminRequestValidatorSettings { get; } = adminRequestValidatorSettings;
    public IEnumerable<EthereumAddress> UsersToValidateOrder { get; } = usersToValidateOrder;
    public IEnumerable<IValidatedScheduleItem> SchedulesToValidateOrder { get; } = schedulesToValidateOrder;
}