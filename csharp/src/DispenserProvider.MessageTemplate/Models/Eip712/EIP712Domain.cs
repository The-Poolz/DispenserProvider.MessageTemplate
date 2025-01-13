using Nethereum.ABI.EIP712;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace DispenserProvider.MessageTemplate.Models.Eip712;

[Struct("EIP712Domain")]
public class EIP712Domain(bool isCreate) : IDomain
{
    public const string CreateName = "Poolz - Create dispenser";
    public const string DeleteName = "Poolz - Delete dispenser";

    [Parameter(type: "string", name: "name", order: 1)]
    public string Name { get; } = isCreate ? CreateName : DeleteName;
}