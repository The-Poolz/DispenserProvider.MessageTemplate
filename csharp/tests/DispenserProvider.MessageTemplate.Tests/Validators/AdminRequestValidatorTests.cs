using Xunit;
using FluentAssertions;
using FluentValidation;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Validators;
using DispenserProvider.MessageTemplate.Tests.Mocks;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Tests.Validators;

public class AdminRequestValidatorTests
{
    public class ValidateAndThrow
    {
        private readonly AdminRequestValidator _validator = new(
            MockAuthContext.Create(),
            new OrderedUsersValidator()
        );

        [Fact]
        internal void WhenNameOfRoleNotMatch_ShouldThrowException()
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: MockMessages.CreateMessage,
                nameOfRole: "invalid role name",
                usersToValidateOrder: MockMessages.CreateMessage.Users.Select(x => new EthereumAddress(x.UserAddress)),
                privateKey: MockUsers.Admin.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should()
                .Throw<ValidationException>()
                .WithMessage($"Validation failed: {Environment.NewLine} -- : Recovered address '{MockUsers.Admin.Address}' is not 'invalid role name'. Severity: Error");
        }

        [Fact]
        internal void WhenAddressNotMatch_ShouldThrowException()
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: MockMessages.CreateMessage,
                nameOfRole: MockAuthContext.Role.Name,
                usersToValidateOrder: MockMessages.CreateMessage.Users.Select(x => new EthereumAddress(x.UserAddress)),
                privateKey: MockUsers.UnauthorizedUser.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should()
                .Throw<ValidationException>()
                .WithMessage($"Validation failed: {Environment.NewLine} -- : Recovered address '{MockUsers.UnauthorizedUser.Address}' is not '{MockAuthContext.Role.Name}'. Severity: Error");
        }

        [Fact]
        internal void WhenCollectionIsEmpty_ShouldThrowException()
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: MockMessages.CreateMessage,
                nameOfRole: MockAuthContext.Role.Name,
                usersToValidateOrder: Array.Empty<EthereumAddress>(),
                privateKey: MockUsers.Admin.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().Throw<ValidationException>()
                .WithMessage($"Validation failed: {Environment.NewLine} -- UsersToValidateOrder: Collection of users cannot be empty. Severity: Error");
        }

        [Fact]
        internal void WhenCollectionNotSorted_ShouldThrowException()
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: MockMessages.CreateMessage,
                nameOfRole: MockAuthContext.Role.Name,
                usersToValidateOrder: [
                    "0x0000000000000000000000000000000000000002",
                    "0x0000000000000000000000000000000000000001"
                ],
                privateKey: MockUsers.Admin.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().Throw<ValidationException>()
                .WithMessage($"Validation failed: {Environment.NewLine} -- UsersToValidateOrder.OrderCheck[0]: Addresses must be in ascending order. Found '0x0000000000000000000000000000000000000002' > '0x0000000000000000000000000000000000000001' Severity: Error");
        }

        [Theory]
        [MemberData(nameof(Messages))]
        internal void WhenRequestIsValid_ShouldWithoutThrownException(AbstractMessage message, IEnumerable<EthereumAddress> users)
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: message,
                nameOfRole: MockAuthContext.Role.Name,
                usersToValidateOrder: users,
                privateKey: MockUsers.Admin.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().NotThrow<ValidationException>();
        }

        public static IEnumerable<object[]> Messages =>
        [
            [
                MockMessages.CreateMessage,
                MockMessages.CreateMessage.Users.Select(x => new EthereumAddress(x.UserAddress)).ToArray()
            ],
            [
                MockMessages.CreateMessageWithRefund,
                MockMessages.CreateMessageWithRefund.Users.Select(x => new EthereumAddress(x.UserAddress)).ToArray()
            ],
            [
                MockMessages.DeleteMessage,
                MockMessages.DeleteMessage.Users.Select(x => new EthereumAddress(x)).ToArray()
            ],
        ];
    }
}
