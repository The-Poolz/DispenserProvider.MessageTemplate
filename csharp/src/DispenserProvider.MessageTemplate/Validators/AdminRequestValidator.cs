﻿using AuthDB;
using FluentValidation;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Validators;

public class AdminRequestValidator<TMessage> : AbstractValidator<AdminValidationRequest<TMessage>>
    where TMessage : IPlainMessage
{
    public AdminRequestValidator(AuthContext authContext, IValidator<IEnumerable<EthereumAddress>> orderValidator)
    {
        RuleFor(request => request)
            .Must(request => IsValidAdmin(request, authContext))
            .WithMessage(request => $"Recovered address '{request.RecoveredAddress}' is not '{request.NameOfRole}'.")
            .DependentRules(() => {
                RuleFor(request => request.UsersToValidateOrder)
                    .SetValidator(orderValidator);
            });
    }

    private static bool IsValidAdmin(AdminValidationRequest<TMessage> request, AuthContext authContext) => authContext.Users
        .Join(
            authContext.Roles,
            user => user.RoleId,
            role => role.Id,
            (user, role) => new { user, role }
        )
        .Any(x => x.role.Name == request.NameOfRole && x.user.Name == request.RecoveredAddress);
}