using FluentValidation;
using Net.Web3.EthereumWallet;
using Net.Utils.ErrorHandler.Extensions;

namespace DispenserProvider.MessageTemplate.Validators;

public class OrderedUsersValidator : AbstractValidator<IEnumerable<EthereumAddress>>
{
    public OrderedUsersValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(users => users)
            .NotEmpty()
            .WithError(Error.USERS_COLLECTION_IS_EMPTY);

        RuleForEach(users => GetZippedPairs(users.ToArray()))
            .Configure(config => config.PropertyName = "Users")
            .Must(pair => !pair.Item1.Equals(pair.Item2))
            .WithError(Error.USERS_COLLECTION_CONTAIN_DUPLICATES);

        RuleForEach(users => GetZippedPairs(users.ToArray()))
            .Configure(config => config.PropertyName = "Users")
            .Must(pair => string.Compare(pair.Item1, pair.Item2) <= 0)
            .WithError(Error.USERS_COLLECTION_MUST_BE_SORTED);
    }

    private static IEnumerable<(EthereumAddress, EthereumAddress)> GetZippedPairs(EthereumAddress[] users) =>
        users.Zip(users.Skip(1));
}