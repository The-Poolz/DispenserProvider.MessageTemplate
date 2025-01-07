using Newtonsoft.Json;
using Net.Web3.EthereumWallet;

namespace MessageTemplate.Examples.Models.Create;

public class User
{
    [JsonRequired]
    public EthereumAddress UserAddress { get; set; } = null!;

    [JsonRequired]
    public string WeiAmount { get; set; } = null!;
}