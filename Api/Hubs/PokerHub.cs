namespace Api.Hubs;

using _SharedSignalR.PokerData;
using Microsoft.AspNetCore.SignalR;

public class PokerHub : Hub
{
	public async Task SendMessageToUsers(string message)
	{
		await Clients.All.SendAsync("ReceiveMessage", message);
	}

	public async Task Question(PokerQuestionData question)
	{
		//await Clients.All.SendAsync("Question", question);
		await Clients.Group(question.RoomName).SendAsync("Question", question);
	}

	public async Task Vote(PokerVoteData vote)
	{
		//await Clients.All.SendAsync("Vote", vote);
		string[] exluded = { $"{Context.ConnectionId}" };
		await Clients.GroupExcept(vote.RoomName,exluded).SendAsync("Vote", vote);
	}

	public async Task JoinRoom(PokerDTO settings)
	{
		var id = Context.ConnectionId;
		await Groups.AddToGroupAsync(id, settings.Room);
		await Vote(new PokerVoteData() { Value = $"{settings.UserName} has joined the room", RoomName = settings.Room });
	}
	public async Task RoomInvite(PokerInvite invite)
	{
		await Clients.All.SendAsync("RoomInvite", invite);
	}
}
