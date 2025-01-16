using Xunit;
using FluentAssertions;
using FluentValidation;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Validators;
using DispenserProvider.MessageTemplate.Tests.Mocks;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Tests.Validators;

public class DeleteValidatorTests
{
    public class ValidateAndThrow
    {
        private readonly DeleteValidator _validator = new(MockAuthContext.Create());

        [Fact]
        internal void WhenDeleteMessageIsValid_ShouldWithoutThrownException()
        {
            var settings = new DeleteValidatorSettings(
                MockAdminRequestValidatorSettings.Create(
                    message: MockMessages.DeleteMessage,
                    nameOfRole: MockAuthContext.Role.Name,
                    privateKey: MockUsers.Admin.PrivateKey
                ),
                users: MockMessages.DeleteMessage.Users.Select(x => new EthereumAddress(x))
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().NotThrow<ValidationException>();
        }
    }
}