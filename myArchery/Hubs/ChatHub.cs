using Microsoft.AspNetCore.SignalR;

namespace myArchery.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",name, message);
        }

        public async Task SendMessageInGroup(int eventId, string name, string message)
        {
            await Clients.Group(eventId.ToString()).SendAsync("ReceiveMessage", name, message);
            Console.WriteLine("Message Sent");
        }

        public async Task AddToGroup(int eventId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, eventId.ToString());
        }

        public async Task RemoveFromGroup(int eventId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, eventId.ToString());
        }
    }
}