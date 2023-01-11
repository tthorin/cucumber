using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageToUsers(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
