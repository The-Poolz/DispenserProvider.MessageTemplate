﻿using AuthDB;
using FluentValidation;
using Net.Web3.EthereumWallet;
using TokenSchedule.FluentValidation;
using TokenSchedule.FluentValidation.Models;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class CreateValidator : AbstractValidator<CreateValidatorSettings>
{
    public CreateValidator(AuthContext authContext)
        : this(
            new AdminRequestValidator(authContext),
            new OrderedUsersValidator(),
            new OrderedScheduleValidator(),
            new ScheduleValidator()
        )
    { }

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

        RuleFor(x => x.Users)
            .SetValidator(usersOrderValidator);

        RuleFor(x => x.Schedule)
            .SetValidator(scheduleValidator);

        RuleFor(x => x.Schedule)
            .SetValidator(scheduleOrderValidator);
    }
}