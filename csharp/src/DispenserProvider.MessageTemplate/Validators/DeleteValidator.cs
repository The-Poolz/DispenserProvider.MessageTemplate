using FluentValidation;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Services;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class DeleteValidator : AbstractValidator<DeleteValidatorSettings>
{
    internal DeleteValidator(IAdminValidationService validationService)
        : this(
            new AdminRequestValidator(validationService),
            new OrderedUsersValidator()
        )
    { }

    public DeleteValidator(AdminRequestValidator adminValidator, IValidator<IEnumerable<EthereumAddress>> usersOrderValidator)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.AdminRequestValidatorSettings)
            .SetValidator(adminValidator);

        RuleFor(x => x.Users)
            .SetValidator(usersOrderValidator);
    }
}