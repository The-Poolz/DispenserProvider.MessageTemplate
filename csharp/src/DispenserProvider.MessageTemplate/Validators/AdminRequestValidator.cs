using FluentValidation;
using Net.Utils.ErrorHandler.Extensions;
using DispenserProvider.MessageTemplate.Services;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class AdminRequestValidator : AbstractValidator<AdminRequestValidatorSettings>
{
    public AdminRequestValidator(IAdminValidationService validationService)
    {
        RuleFor(request => request)
            .Must(request => validationService.IsValidAdmin(request.RecoveredAddress))
            .WithError(Error.RECOVERED_ADDRESS_IS_INVALID)
            .WithState(request => new
            {
                request.RecoveredAddress
            });
    }
}
