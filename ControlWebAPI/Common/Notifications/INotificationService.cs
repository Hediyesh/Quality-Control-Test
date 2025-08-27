using ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts;

namespace ControlWebAPI.Common.Notifications
{
    public interface INotificationService
    {
        Task SendDailyCountsUpdateAsync(List<DailyCountDto> dailyCounts);
    }
}
