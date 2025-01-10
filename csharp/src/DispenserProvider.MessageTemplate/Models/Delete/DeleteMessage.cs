using System.Numerics;
using Net.Web3.EthereumWallet;
using DispenserProvider.MessageTemplate.Models.Eip712;

namespace DispenserProvider.MessageTemplate.Models.Delete;

public class DeleteMessage(long chainId, long poolId, EthereumAddress[] users) : AbstractMessage
{
    public BigInteger ChainId { get; } = chainId;

    public BigInteger PoolId { get; } = poolId;

    public string[] Users { get; } = users.Select(x => x.Address).ToArray();

    public override bool IsCreate => false;
    public override Type[] MembersDescriptionTypes => [typeof(DeleteMessage)];
}