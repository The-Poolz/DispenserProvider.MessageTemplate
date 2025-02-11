using FluentValidation;
using Net.Utils.ErrorHandler.Extensions;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Validators;

public class OrderedScheduleValidator : AbstractValidator<IEnumerable<IValidatedScheduleItem>>
{
    public OrderedScheduleValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .NotEmpty()
            .WithError(Error.SCHEDULE_IS_EMPTY);

        RuleFor(x => x.ToArray())
            .Must(x => x.OrderBy(item => item.StartDate).SequenceEqual(x))
            .WithError(Error.SCHEDULE_MUST_BE_SORTED);
    }
}