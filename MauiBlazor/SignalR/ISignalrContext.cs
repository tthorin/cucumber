namespace MauiBlazor.SignalR;

using _SharedSignalR.Models;
using _SharedSignalR.Models.EventModels;
using _SharedSignalR.Enums;

internal interface ISignalrContext
{
	public UserSettings Settings { get; set; }
	public bool Connected { get; }
	Task Start();
	ValueTask DisposeAsync();
	Task SendPokerVote(string vote);
	Task SendPokerQuestion(PokerObject question);
	Task SendNavigationObject(Pages navigation);
	Task JoinRoom();
    Task<bool> GroupNameExists(string groupName);
    Task<bool> AddGroupName(string groupName);
	IDisposable OnPokerQuestion(Action<PokerObject> action);
	IDisposable OnJoin(Action<JoinRoomData> action);
	IDisposable OnPokerVote(Action<PokerVote> action);
	IDisposable OnPokerResults(Action<PokerVoteResults> action);
	IDisposable OnNavigation(Action<NavigationObject> action);
}