﻿using Xunit;
using FluentAssertions;
using FluentValidation;
using DispenserProvider.MessageTemplate.Validators;
using DispenserProvider.MessageTemplate.Tests.Mocks;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Tests.Validators;

public class AdminRequestValidatorTests
{
    public class ValidateAndThrow
    {
        private readonly AdminRequestValidator _validator = new(MockAuthContext.Create());

        [Fact]
        internal void WhenNameOfRoleNotMatch_ShouldThrowException()
        {
            var invalidRoleName = "invalid role name";
            var settings = MockAdminRequestValidatorSettings.Create(
                message: MockMessages.CreateMessage,
                nameOfRole: invalidRoleName,
                privateKey: MockUsers.Admin.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be($"Recovered address '{MockUsers.Admin.Address}' is not '{invalidRoleName}'.");
        }

        [Fact]
        internal void WhenAddressNotMatch_ShouldThrowException()
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: MockMessages.CreateMessage,
                nameOfRole: MockAuthContext.Role.Name,
                privateKey: MockUsers.UnauthorizedUser.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be($"Recovered address '{MockUsers.UnauthorizedUser.Address}' is not '{MockAuthContext.Role.Name}'.");
        }

        [Theory]
        [MemberData(nameof(Messages))]
        internal void WhenRequestIsValid_ShouldWithoutThrownException(AbstractMessage message)
        {
            var settings = MockAdminRequestValidatorSettings.Create(
                message: message,
                nameOfRole: MockAuthContext.Role.Name,
                privateKey: MockUsers.Admin.PrivateKey
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().NotThrow<ValidationException>();
        }

        public static IEnumerable<object[]> Messages =>
        [
            [MockMessages.CreateMessage],
            [MockMessages.CreateMessageWithRefund],
            [MockMessages.DeleteMessage]
        ];
    }
}
