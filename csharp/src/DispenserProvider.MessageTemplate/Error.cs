using Net.Utils.ErrorHandler.Attributes;
using TokenSchedule.FluentValidation.Models;

namespace DispenserProvider.MessageTemplate;

public enum Error
{
    [Error("Recovered address is not valid.")]
    RECOVERED_ADDRESS_IS_INVALID,
    [Error("Schedule must contain 1 or more elements.")]
    SCHEDULE_IS_EMPTY,
    [Error($"Schedule must be sorted in ascending order by '{nameof(IValidatedScheduleItem.StartDate)}'.")]
    SCHEDULE_MUST_BE_SORTED,
    [Error("Collection of users must contain 1 or more elements.")]
    USERS_COLLECTION_IS_EMPTY,
    [Error("Collection of users must be sorted by ascending.")]
    USERS_COLLECTION_MUST_BE_SORTED,
    [Error("Collection of users contain duplicates.")]
    USERS_COLLECTION_CONTAIN_DUPLICATES
}