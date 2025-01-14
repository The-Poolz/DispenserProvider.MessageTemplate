using AuthDB;
using FluentValidation;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class AdminRequestValidator : AbstractValidator<AdminRequestValidatorSettings>
{
    public AdminRequestValidator(AuthContext authContext)
    {
        RuleFor(request => request)
            .Must(request => IsValidAdmin(request, authContext))
            .WithMessage(request => $"Recovered address '{request.RecoveredAddress}' is not '{request.NameOfRole}'.");
    }

    private static bool IsValidAdmin(AdminRequestValidatorSettings request, AuthContext authContext) => authContext.Users
        .Join(
            authContext.Roles,
            user => user.RoleId,
            role => role.Id,
            (user, role) => new { user, role }
        )
        .Any(x => x.role.Name == request.NameOfRole && x.user.Name == request.RecoveredAddress);
}