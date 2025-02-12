using Nethereum.Util;
using System.Numerics;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

public class MockValidatedScheduleItem(decimal ratio, DateTime startDate, DateTime? finishDate) : IValidatedScheduleItem
{
    public MockValidatedScheduleItem(decimal ratio, long startDate, long? finishDate)
        : this(ratio, DateTimeOffset.FromUnixTimeSeconds(startDate).UtcDateTime, !finishDate.HasValue ? null : DateTimeOffset.FromUnixTimeSeconds(finishDate.Value).UtcDateTime)
    { }

    public MockValidatedScheduleItem(BigInteger ratio, BigInteger startDate, BigInteger finishDate)
        : this(
            UnitConversion.Convert.FromWei(ratio, 18),
            DateTimeOffset.FromUnixTimeSeconds((long)startDate).UtcDateTime,
            finishDate == 0 ? null : DateTimeOffset.FromUnixTimeSeconds((long)finishDate).UtcDateTime
        )
    { }

    public MockValidatedScheduleItem(string ratio, BigInteger startDate, BigInteger finishDate)
        : this(BigInteger.Parse(ratio), startDate, finishDate)
    { }

    public decimal Ratio { get; } = ratio;
    public DateTime StartDate { get; } = startDate;
    public DateTime? FinishDate { get; } = finishDate;
}