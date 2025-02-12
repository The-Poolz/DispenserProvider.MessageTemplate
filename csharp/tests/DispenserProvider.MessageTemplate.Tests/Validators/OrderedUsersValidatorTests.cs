using Xunit;
using FluentAssertions;
using FluentValidation;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Validators;

namespace DispenserProvider.MessageTemplate.Tests.Validators;

public class OrderedUsersValidatorTests
{
    public class ValidateAndThrow
    {
        private readonly OrderedUsersValidator _validator = new();

        [Fact]
        internal void WhenCollectionIsEmpty_ShouldThrowException()
        {
            var users = Array.Empty<EthereumAddress>();

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().HaveCount(1)
                .And.ContainSingle()
                .Which.Should().BeEquivalentTo(new
                {
                    ErrorCode = "USERS_COLLECTION_IS_EMPTY",
                    ErrorMessage = "Collection of users must contain 1 or more elements."
                });
        }

        [Fact]
        internal void WhenCollectionNotSorted_ShouldThrowException()
        {
            var users = new EthereumAddress[] {
                "0x0000000000000000000000000000000000000002",
                "0x0000000000000000000000000000000000000001"
            };

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().HaveCount(1)
                .And.ContainSingle()
                .Which.Should().BeEquivalentTo(new
                {
                    ErrorCode = "USERS_COLLECTION_MUST_BE_SORTED",
                    ErrorMessage = "Collection of users must be sorted by ascending."
                });
        }

        [Fact]
        internal void WhenCollectionNotUnique_ShouldThrowException()
        {
            var users = new EthereumAddress[] {
                "0x0000000000000000000000000000000000000002",
                "0x0000000000000000000000000000000000000002"
            };

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().HaveCount(1)
                .And.ContainSingle()
                .Which.Should().BeEquivalentTo(new
                {
                    ErrorCode = "USERS_COLLECTION_CONTAIN_DUPLICATES",
                    ErrorMessage = "Collection of users contain duplicates."
                });
        }

        [Fact]
        internal void WhenCollectionNotUniqueAndNotSorted_ShouldThrowException()
        {
            var users = new EthereumAddress[] {
                "0x0000000000000000000000000000000000000002",
                "0x0000000000000000000000000000000000000002",
                "0x0000000000000000000000000000000000000001"
            };

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().Throw<ValidationException>()
                .Which.Errors.Should().HaveCount(2)
                .And.Contain(x =>
                    x.ErrorCode == "USERS_COLLECTION_CONTAIN_DUPLICATES" &&
                    x.ErrorMessage == "Collection of users contain duplicates."
                )
                .And.Contain(x =>
                    x.ErrorCode == "USERS_COLLECTION_MUST_BE_SORTED" &&
                    x.ErrorMessage == "Collection of users must be sorted by ascending."
                );
        }

        [Fact]
        internal void WhenCollectionSortedRight_ShouldNotThrowException()
        {
            var users = new EthereumAddress[] {
                "0x0000000000000000000000000000000000000001",
                "0x0000000000000000000000000000000000000002"
            };

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().NotThrow<ValidationException>();
        }

        [Fact]
        internal void WhenCollectionWithOneElement_ShouldNotThrowException()
        {
            var users = new EthereumAddress[] {
                "0x0000000000000000000000000000000000000001"
            };

            var testCode = () => _validator.ValidateAndThrow(users);

            testCode.Should().NotThrow<ValidationException>();
        }
    }
}
