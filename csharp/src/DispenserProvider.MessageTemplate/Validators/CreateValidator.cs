using FluentValidation;
using Net.Web3.EthereumWallet;
using TokenSchedule.FluentValidation;
using TokenSchedule.FluentValidation.Models;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class CreateValidator : AbstractValidator<CreateValidatorSettings>
{
    public CreateValidator(
        AdminRequestValidator adminValidator,
        IValidator<IEnumerable<EthereumAddress>> usersOrderValidator,
        IValidator<IEnumerable<IValidatedScheduleItem>> scheduleOrderValidator,
        ScheduleValidator scheduleValidator
    )
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.AdminRequestValidatorSettings)
            .SetValidator(adminValidator);

        RuleFor(x => x.UsersToValidateOrder)
            .SetValidator(usersOrderValidator);

        RuleFor(x => x.SchedulesToValidateOrder)
            .SetValidator(scheduleValidator);

        RuleFor(x => x.SchedulesToValidateOrder)
            .SetValidator(scheduleOrderValidator);
    }
}