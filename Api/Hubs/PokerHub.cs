namespace Api.Hubs;

using _SharedSignalR.Models;
using Microsoft.AspNetCore.SignalR;

public class PokerHub : Hub
{
	readonly IGroupNamesService _groupNamesService;
	public PokerHub(IGroupNamesService groupNamesService)
	{
		_groupNamesService = groupNamesService;
	}
    public bool GroupNameExists(string groupName)
    {
		return _groupNamesService.GroupNames.Contains(groupName);
    }
	public async Task GetRoomNamesInUse()
	{
		var connectionId = Context.ConnectionId;
		var roomNamesInUse = _groupNamesService.GroupNames;
		await Clients.Client(connectionId).SendAsync("RoomNamesInUse", roomNamesInUse);
	}
    public bool AddGroupName(string groupName)
    {
        return _groupNamesService.GroupNames.Add(groupName);
    }
    public async Task SendMessageToUsers(string message)
	{
		await Clients.All.SendAsync("ReceiveMessage", message);
	}

	public async Task PokerQuestion(PokerObject question)
	{
		await Clients.Group(question.Room).SendAsync("PokerQuestion", question);
	}

	public async Task PokerVote(PokerVote vote)
	{
		string[] exluded = { $"{Context.ConnectionId}" };
		await Clients.GroupExcept(vote.RoomName,exluded).SendAsync("PokerAnswer", vote);
	}

	public async Task JoinRoom(JoinRoomData settings)
	{
        var id = Context.ConnectionId;
		await Groups.AddToGroupAsync(id, settings.User.Room);
        await Clients.GroupExcept(settings.User.Room, id).SendAsync("JoinRoom", settings);
    }
	public async Task PokerResults(PokerVoteResults results)
	{
		await Clients.Group(results.Room).SendAsync("PokerResults", results);
	}
}
