using ControlApplication.Common.Notifications;
using ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts;
using ControlWebAPI.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ControlWebAPI.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<QualityControlHub> _hub;

        public NotificationService(IHubContext<QualityControlHub> hub)
        {
            _hub = hub;
        }

        public async Task SendDailyCountsUpdateAsync(List<DailyCountDto> dailyCounts)
        {
            await _hub.Clients.All.SendAsync("UpdateDailyCounts", dailyCounts);
        }
    }
}
