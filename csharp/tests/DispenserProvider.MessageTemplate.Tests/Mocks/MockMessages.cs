using DispenserProvider.MessageTemplate.Models.Create;
using DispenserProvider.MessageTemplate.Models.Delete;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

internal static class MockMessages
{
    internal static CreateMessage CreateMessage => new(
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

    internal static CreateMessageWithRefund CreateMessageWithRefund => new(
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

    internal static DeleteMessage DeleteMessage => new(
        chainId: 1,
        poolId: 1,
        users:
        [
            "0x0000000000000000000000000000000000000001",
            "0x0000000000000000000000000000000000000002"
        ]
    );
}