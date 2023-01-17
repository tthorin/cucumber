using _SharedSignalR.Models;
using Microsoft.Extensions.Configuration;

namespace MauiBlazor.SignalR
{
	internal interface ISignalrContext
	{
		public UserSettings Settings { get; set; }
		Task Start();
		ValueTask DisposeAsync();
		Task SendPokerVote(string vote);
		Task SendPokerQuestion(string feature);
		Task Join();
		IDisposable OnPokerQuestion(Action<PokerObject> action);
		IDisposable OnJoin(Action<JoinRoomData> action);
		IDisposable OnPokerVote(Action<PokerVote> action);
		IDisposable OnPokerResults(Action<PokerVote> action);
	}
}