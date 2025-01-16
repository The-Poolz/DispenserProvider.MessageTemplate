using Net.Web3.EthereumWallet;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class CreateValidatorSettings(
    AdminRequestValidatorSettings adminValidatorSettings,
    IEnumerable<EthereumAddress> users,
    IEnumerable<IValidatedScheduleItem> schedule
) : BaseValidatorSettings(adminValidatorSettings, users)
{
    public IEnumerable<IValidatedScheduleItem> Schedule { get; } = schedule;
}