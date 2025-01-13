using DispenserProvider.MessageTemplate.Models.Create;

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
}