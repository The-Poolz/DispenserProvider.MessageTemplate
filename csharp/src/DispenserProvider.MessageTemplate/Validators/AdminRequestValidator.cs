using AuthDB;
using FluentValidation;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class AdminRequestValidator : AbstractValidator<AdminRequestValidatorSettings>
{
    public AdminRequestValidator(AuthContext authContext, IValidator<IEnumerable<EthereumAddress>> orderValidator)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(request => request)
            .Must(request => IsValidAdmin(request, authContext))
            .WithMessage(request => $"Recovered address '{request.RecoveredAddress}' is not '{request.NameOfRole}'.");

        RuleFor(request => request.UsersToValidateOrder)
            .SetValidator(orderValidator);
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