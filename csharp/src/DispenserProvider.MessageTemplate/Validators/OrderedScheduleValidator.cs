using FluentValidation;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Validators;

public class OrderedScheduleValidator : AbstractValidator<IEnumerable<IValidatedScheduleItem>>
{
    public OrderedScheduleValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Schedule must contain 1 or more elements.");

        RuleFor(x => x.ToArray())
            .Must(x => x.OrderBy(item => item.StartDate).SequenceEqual(x))
            .WithMessage($"Schedule must be sorted in ascending order by {nameof(IValidatedScheduleItem.StartDate)}.");
    }
}