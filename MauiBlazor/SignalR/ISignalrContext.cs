namespace MauiBlazor.SignalR;

using _SharedSignalR.Models;
using _SharedSignalR.Models.EventModels;
using _SharedSignalR.Enums;

internal interface ISignalrContext
{
	public UserSettings Settings { get; set; }
	Task Start();
	ValueTask DisposeAsync();
	Task SendPokerVote(string vote);
	Task SendPokerQuestion(PokerObject question);
	Task SendNavigationObject(Pages navigation);
	Task JoinRoom();
	public bool Connected { get; }
	IDisposable OnPokerQuestion(Action<PokerObject> action);
	IDisposable OnJoin(Action<JoinRoomData> action);
	IDisposable OnPokerVote(Action<PokerVote> action);
	IDisposable OnPokerResults(Action<PokerVoteResults> action);
	IDisposable OnNavigation(Action<NavigationObject> action);
}