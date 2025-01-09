using Newtonsoft.Json;

namespace DispenserProvider.MessageTemplate.Models.Validators;

public class ValidatedAdminRequest<TMessage>
    where TMessage : IPlainMessage
{
    [JsonRequired]
    public string Signature { get; set; } = null!;

    [JsonRequired]
    public TMessage Message { get; set; } = default!;
}