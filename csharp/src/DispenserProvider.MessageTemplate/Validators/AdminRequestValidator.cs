using FluentValidation;
using DispenserProvider.MessageTemplate.Services;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class AdminRequestValidator : AbstractValidator<AdminRequestValidatorSettings>
{
    public AdminRequestValidator(IAdminValidationService validationService)
    {
        RuleFor(request => request)
            .Must(request => validationService.IsValidAdmin(request.RecoveredAddress, request.NameOfRole))
            .WithMessage(request => $"Recovered address '{request.RecoveredAddress}' is not '{request.NameOfRole}'.");
    }
}