using Newtonsoft.Json;
using Net.Web3.EthereumWallet;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public interface IPlainMessage
{
    [JsonIgnore]
    public IEnumerable<EthereumAddress> UsersToValidateOrder { get; }
}