using System.Numerics;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

public class MockValidatedScheduleItem(BigInteger ratio, DateTime startDate, DateTime? finishDate) : IValidatedScheduleItem
{
    public MockValidatedScheduleItem(BigInteger ratio, BigInteger startDate, BigInteger? finishDate)
        : this(ratio,
            DateTimeOffset.FromUnixTimeSeconds((long)startDate).UtcDateTime,
            finishDate > 0 ? DateTimeOffset.FromUnixTimeSeconds((long)finishDate.Value).UtcDateTime : null
        )
    { }

    public MockValidatedScheduleItem(string ratio, BigInteger startDate, BigInteger? finishDate)
        : this(BigInteger.Parse(ratio), startDate, finishDate)
    { }

    public BigInteger Ratio { get; } = ratio;
    public DateTime StartDate { get; } = startDate;
    public DateTime? FinishDate { get; } = finishDate;
}