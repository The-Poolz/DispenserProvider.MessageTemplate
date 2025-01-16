using Xunit;
using FluentAssertions;
using FluentValidation;
using TokenSchedule.FluentValidation.Models;
using DispenserProvider.MessageTemplate.Validators;
using DispenserProvider.MessageTemplate.Tests.Mocks;

namespace DispenserProvider.MessageTemplate.Tests.Validators;

public class OrderedScheduleValidatorTests
{
    public class ValidateAndThrow
    {
        private readonly OrderedScheduleValidator _validator = new();

        [Fact]
        internal void WhenCollectionIsEmpty_ShouldThrowException()
        {
            var users = Array.Empty<IValidatedScheduleItem>();

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be("Schedule must contain 1 or more elements.");
        }

        [Fact]
        internal void WhenCollectionNotSorted_ShouldThrowException()
        {
            var schedule = new MockValidatedScheduleItem[] {
                new(0.5m, 170000, 0),
                new(0.5m, 160000, 0)
            };

            var testCode = () => _validator.ValidateAndThrow(schedule);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be("Schedule must be sorted in ascending order by 'StartDate'.");
        }

        [Fact]
        internal void WhenCollectionNotUnique_ShouldThrowException()
        {
            var schedule = new MockValidatedScheduleItem[] {
                new(0.5m, 170000, 0),
                new(0.5m, 170000, 0)
            };

            var testCode = () => _validator.ValidateAndThrow(schedule);

            testCode.Should().NotThrow<ValidationException>();
        }

        [Fact]
        internal void WhenCollectionSortedRight_ShouldNotThrowException()
        {
            var schedule = new MockValidatedScheduleItem[] {
                new(0.5m, 160000, 0),
                new(0.5m, 170000, 190000)
            };

            var testCode = () => _validator.ValidateAndThrow(schedule);

            testCode.Should().NotThrow<ValidationException>();
        }

        [Fact]
        internal void WhenCollectionWithOneElement_ShouldNotThrowException()
        {
            var schedule = new MockValidatedScheduleItem[] {
                new(1, 170000, 190000)
            };

            var testCode = () => _validator.ValidateAndThrow(schedule);

            testCode.Should().NotThrow<ValidationException>();
        }
    }
}