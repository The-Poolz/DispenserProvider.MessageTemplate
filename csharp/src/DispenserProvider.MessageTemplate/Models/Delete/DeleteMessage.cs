using System.Numerics;
using Nethereum.ABI.EIP712;
using Net.Web3.EthereumWallet;
using Nethereum.ABI.FunctionEncoding.Attributes;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Delete;

[Struct(name: "SignMessage")]
public class DeleteMessage(long chainId, long poolId, IEnumerable<EthereumAddress> users) : AbstractMessage
{
    public BigInteger ChainId { get; } = chainId;

    public BigInteger PoolId { get; } = poolId;

    public string[] Users { get; } = users.Select(x => x.Address).ToArray();

    protected override bool IsCreate => false;
    protected override Type[] MembersDescriptionTypes => [typeof(DeleteMessage)];
    protected override MemberValue[] MembersValues => MemberValueFactory.CreateFromMessage(this);
}