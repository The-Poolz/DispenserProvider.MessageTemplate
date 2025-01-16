using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate.Tests.Mocks;

public class MockValidatedScheduleItem(decimal ratio, DateTime startDate, DateTime? finishDate) : IValidatedScheduleItem
{
    public MockValidatedScheduleItem(decimal ratio, long startDate, long finishDate)
        : this(ratio, DateTimeOffset.FromUnixTimeSeconds(startDate).UtcDateTime, DateTimeOffset.FromUnixTimeSeconds(finishDate).UtcDateTime)
    { }

    public decimal Ratio { get; } = ratio;
    public DateTime StartDate { get; } = startDate;
    public DateTime? FinishDate { get; } = finishDate;
}