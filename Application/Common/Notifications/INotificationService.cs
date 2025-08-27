using ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts;


namespace ControlApplication.Common.Notifications
{
    public interface INotificationService
    {
        Task SendDailyCountsUpdateAsync(List<DailyCountDto> dailyCounts);
    }
}
