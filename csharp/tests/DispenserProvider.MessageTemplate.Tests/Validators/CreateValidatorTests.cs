using Xunit;
using FluentValidation;
using FluentAssertions;
using Net.Web3.EthereumWallet;
using TokenSchedule.FluentValidation.Models;
using DispenserProvider.MessageTemplate.Validators;
using DispenserProvider.MessageTemplate.Tests.Mocks;
using DispenserProvider.MessageTemplate.Models.Eip712;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Tests.Validators;

public class CreateValidatorTests
{
    public class ValidateAndThrow
    {
        private readonly CreateValidator _validator = new(new MockAdminValidationService());

        [Theory]
        [MemberData(nameof(Messages))]
        internal void WhenCreateMessageIsValid_ShouldWithoutThrownException(AbstractMessage message, IEnumerable<EthereumAddress> users, IEnumerable<IValidatedScheduleItem> schedule)
        {
            var settings = new CreateValidatorSettings(
                MockAdminRequestValidatorSettings.Create(
                    message: MockMessages.CreateMessage,
                    nameOfRole: MockAdminValidationService.Role,
                    privateKey: MockUsers.Admin.PrivateKey
                ),
                users: users,
                schedule: schedule
            );

            var testCode = () => _validator.ValidateAndThrow(settings);

            testCode.Should().NotThrow<ValidationException>();
        }

        public static IEnumerable<object[]> Messages =>
        [
            [
                MockMessages.CreateMessage,
                MockMessages.CreateMessage.Users.Select(x => new EthereumAddress(x.UserAddress)),
                MockMessages.CreateMessage.Schedules.Select(x => new MockValidatedScheduleItem(x.Ratio, x.StartDate, x.FinishDate))
            ],
            [
                MockMessages.CreateMessageWithRefund,
                MockMessages.CreateMessageWithRefund.Users.Select(x => new EthereumAddress(x.UserAddress)),
                MockMessages.CreateMessageWithRefund.Schedules.Select(x => new MockValidatedScheduleItem(x.Ratio, x.StartDate, x.FinishDate))
            ]
        ];
    }
}