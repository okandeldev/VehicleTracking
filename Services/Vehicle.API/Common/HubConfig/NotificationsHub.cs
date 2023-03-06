using Microsoft.AspNetCore.SignalR; 
namespace VehicleAPI.Common.HubConfig
{ 
    public class NotificationsHub : Hub 
    { 
        public async Task SendAsyncToCaller(IHubContext<NotificationsHub> _hub, string method, object arg1)
        {
             await _hub.Clients.All.SendAsync(method, arg1);
        } 
    } 
}
