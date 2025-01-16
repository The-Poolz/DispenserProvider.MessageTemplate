using Net.Web3.EthereumWallet;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class DeleteValidatorSettings(AdminRequestValidatorSettings adminValidatorSettings, IEnumerable<EthereumAddress> users) : BaseValidatorSettings(adminValidatorSettings, users);