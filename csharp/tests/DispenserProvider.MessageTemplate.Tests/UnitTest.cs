using System.Numerics;
using DispenserProvider.MessageTemplate.Models.Create;
using DispenserProvider.MessageTemplate.Models.Eip712;
using DispenserProvider.MessageTemplate.Tests.Mocks;
using FluentAssertions;
using Nethereum.ABI.EIP712;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Nethereum.Util;
using Xunit;

namespace DispenserProvider.MessageTemplate.Tests
{
    public class UnitTest
    {
        private readonly Eip712TypedDataSigner _signer = new Eip712TypedDataSigner();

        [Struct("SignMessage")]
        public class CreateMessage(DispenserProvider.MessageTemplate.Models.Create.CreateMessage createMessage)
        {
            [Parameter(type: "uint256", name: "chainId", order: 1)]
            public BigInteger ChainId { get; } = createMessage.ChainId;

            [Parameter(type: "uint256", name: "poolId", order: 2)]
            public BigInteger PoolId { get; } = createMessage.PoolId;

            [Parameter(type: "tuple[]", name: "schedules", order: 3, structTypeName: "Schedule[]")]
            public List<Schedule> Schedules { get; } = createMessage.Schedules.ToList();

            [Parameter("tuple[]", "users", 4, structTypeName: "User[]")]
            public List<User> Users { get; } = createMessage.Users;
        }

        //The generic EIP712 Typed schema defintion for this message
        public TypedData<EIP712Domain> GetMailTypedDefinition()
        {
            return new TypedData<EIP712Domain>
            {
                Domain = new EIP712Domain(isCreate: true),
                Types = MemberDescriptionFactory.GetTypesMemberDescription(typeof(EIP712Domain), typeof(CreateMessage), typeof(Schedule), typeof(User)),
                PrimaryType = "SignMessage",
            };
        }

        [Fact]
        public void Test()
        {
            var typedData = MockMessages.CreateMessage.TypedData;

            var json = typedData.ToJson();
            var key = new EthECKey("94e001d6adf3a3275d5dd45971c2a5f6637d3e9c51f9693f2e678f649e164fa5");

            var signature = _signer.SignTypedDataV4(MockMessages.CreateMessage, typedData, key);

            var addressRecovered = _signer.RecoverFromSignatureV4(MockMessages.CreateMessage, typedData, signature);
            var address = key.GetPublicAddress();

            Assert.True(address.IsTheSameAddress(addressRecovered));
        }
    }
}