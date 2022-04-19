using Microsoft.AspNetCore.SignalR;
using myArchery.Services;

namespace myArchery.Hubs
{
    public class LiverankingHub : Hub
    {
        private EventService _eventService;
        private ILogger<LiverankingHub> _logger;

        public LiverankingHub(EventService eventService, ILogger<LiverankingHub> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

        public async Task SendRanking(int eventId)
        {
            _logger.LogError("Sent Ranking");
            await Clients.Group(eventId.ToString()).SendAsync("RecieveLeaderboard", Utility.GetUserWithPointsAsJson(_eventService.GetUsersWithPointsFromEventById(eventId)));
        }

        public async Task AddToGroup(int eventId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, eventId.ToString());
            await SendRanking(eventId);
        }

        public async Task RemoveFromGroup(int eventId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, eventId.ToString());
        }
    }
}