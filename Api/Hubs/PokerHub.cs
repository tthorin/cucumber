﻿namespace Api.Hubs;

using _SharedSignalR.PokerData;
using Microsoft.AspNetCore.SignalR;
using SharedData;

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
			await Clients.Group(vote.RoomName).SendAsync("Vote", vote);
		}

    public async Task JoinRoom(string roomName)
    {
        var id = Context.ConnectionId;
        await Groups.AddToGroupAsync(id, roomName);
    }
    public async Task RoomInvite(PokerInvite invite)
    {
        await Clients.All.SendAsync("RoomInvite", invite);
    }
}
