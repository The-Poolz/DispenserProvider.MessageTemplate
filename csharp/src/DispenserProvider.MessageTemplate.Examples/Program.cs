using Nethereum.Signer;
using Nethereum.ABI.EIP712;
using Nethereum.Signer.EIP712;
using DispenserProvider.MessageTemplate.Services;
using DispenserProvider.MessageTemplate.Validators;
using DispenserProvider.MessageTemplate.Models.Create;
using DispenserProvider.MessageTemplate.Models.Delete;
using DispenserProvider.MessageTemplate.Models.Eip712;
using DispenserProvider.MessageTemplate.Models.Validators;

namespace DispenserProvider.MessageTemplate.Examples;

public class Program
{
    public static EthECKey PrivateKey => new("0xe290f27189205c280e53b6194580c24b4fc49c97047b5ffcb62201c4d38feece");

    private static void Main()
    {
        var validationService = new MockAdminValidationService();
        CreateMessage(validationService);
        CreateMessageWithRefund(validationService);
        DeleteMessage(validationService);
    }

    private static void CreateMessage(IAdminValidationService validationService)
    {
        var message = new CreateMessage(
            chainId: 1,
            poolId: 1,
            schedules:
            [
                new Schedule(
                    providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                    ratio: "500000000000000000",
                    startDate: 0,
                    finishDate: 0
                ),
                new Schedule(
                    providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                    ratio: "300000000000000000",
                    startDate: 0,
                    finishDate: 0
                ),
                new Schedule(
                    providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                    ratio: "200000000000000000",
                    startDate: 0,
                    finishDate: 1763758800
                )
            ],
            users:
            [
                new User(
                    userAddress: "0x0000000000000000000000000000000000000001",
                    weiAmount: "50000000000000000000"
                ),
                new User(
                    userAddress: "0x0000000000000000000000000000000000000002",
                    weiAmount: "25000000000000000000"
                )
            ]
        );

        HandleMessage(
            "CREATE MESSAGE",
            message,
            validationService
        );
    }

    private static void CreateMessageWithRefund(IAdminValidationService validationService)
    {
        var message = new CreateMessageWithRefund(
            chainId: 1,
            poolId: 1,
            schedules:
            [
                new Schedule(
                    providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                    ratio: "500000000000000000",
                    startDate: 0,
                    finishDate: 0
                ),
                new Schedule(
                    providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                    ratio: "300000000000000000",
                    startDate: 0,
                    finishDate: 0
                ),
                new Schedule(
                    providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                    ratio: "200000000000000000",
                    startDate: 0,
                    finishDate: 1763758800
                )
            ],
            users:
            [
                new User(
                    userAddress: "0x0000000000000000000000000000000000000001",
                    weiAmount: "50000000000000000000"
                ),
                new User(
                    userAddress: "0x0000000000000000000000000000000000000002",
                    weiAmount: "25000000000000000000"
                )
            ],
            refund: new Refund(
                chainId: 56,
                poolId: 1,
                ratio: "800000000000000000",
                dealProvider: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
                finishTime: 1763544530
            )
        );

        HandleMessage(
            "CREATE MESSAGE WITH REFUND",
            message,
            validationService
        );
    }

    private static void DeleteMessage(IAdminValidationService validationService)
    {
        var message = new DeleteMessage(
            chainId: 1,
            poolId: 1,
            users:
            [
                "0x0000000000000000000000000000000000000001",
                "0x0000000000000000000000000000000000000002"
            ]
        );

        HandleMessage(
            "DELETE MESSAGE",
            message,
            validationService
        );
    }

    private static void HandleMessage(string nameOfOperation, AbstractMessage message, IAdminValidationService validationService)
    {
        Console.WriteLine(new string('=', 64));
        Console.WriteLine(nameOfOperation);
        Console.WriteLine(new string('=', 64));

        var signature = new Eip712TypedDataSigner().SignTypedDataV4<EIP712Domain>(message.TypedData.ToJson(), PrivateKey);

        Console.WriteLine($"GENERATED SIGNATURE: {signature}");
        Console.WriteLine($"DATA: {message.TypedData.ToJson()}");

        var adminRequestValidator = new AdminRequestValidator(validationService);
        var settings = new AdminRequestValidatorSettings(signature, message);

        var validationResult = adminRequestValidator.Validate(settings);

        if (!validationResult.IsValid)
        {
            Console.WriteLine($"VALIDATION FAILED WITH ERROR: {Environment.NewLine}{validationResult}");
        }
    }
}