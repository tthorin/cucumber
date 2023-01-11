using Microsoft.AspNetCore.SignalR;
using SharedData;

namespace Api.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageToUsers(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task Question(PokerQuestionData question)
        {
            await Clients.All.SendAsync("Question", question);
        }

        public async Task Vote(PokerVoteData vote)
        {
            await Clients.All.SendAsync("Vote", vote);
        }
    }
}
