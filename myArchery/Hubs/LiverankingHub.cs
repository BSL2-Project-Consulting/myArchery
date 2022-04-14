using Microsoft.AspNetCore.SignalR;
using myArchery.Services;

namespace myArchery.Hubs
{
    public class LiverankingHub : Hub
    {
        public async Task SendRanking(int eventId)
        {
            await Clients.Group(eventId.ToString()).SendAsync("RecieveLeaderboard", Utility.GetUserWithPointsAsJson(EventService.GetUsersWithPointsFromEventById(eventId)));
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